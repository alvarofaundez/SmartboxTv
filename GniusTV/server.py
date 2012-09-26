#!C:\Python27

from twython import Twython
import nltk
from nltk.corpus import stopwords
from collections import Counter
from db import DB
from time import sleep
import simplejson as json
from bottle import route, run, debug, template

@route('/gnius/<user>/match')
def gnius(user='rafalopezpo'):
	#obtener palabras clave desde la DB
	keywords=keywordsDB()
	#obtener palabras desde la bio
	bio = userBio(user)
	#obtener palabras de la TweetLine del usuario (tweets emitidos por el usuario)
	tl = userTL(user)
	#obtener palabras desde la descripción de los amigos (cuentas a las que el usuario sigue)
	friends = userFriends(user)
	#filtrar y encontrar coincidencias entre las palabras encontradas en las fuentes anteriores y las palabras del diccionario
	match = [word for word in keywords if word in bio or word in tl or word in friends]
	#obtener programación relacionada a las palabras filtradas
	response = categoryDB(match)
	print response
	return json.dumps({'response':response})

def categoryDB(keywords):
	print '%s\n\n\n' % keywords
	db = DB(host='190.215.44.18', port='5432', dbname='GLF', user='postgres', password='$martb0xTv')
	response = []
	for keyword in keywords:
		print keyword
		query = 'SELECT c."channelNumber", c."channelName", s."startDate", s."endDate", p."title", p."description", pc."mscName" \
			FROM "tbl_Channel" c, "tbl_Schedule" s, "tbl_Program" p, "tbl_ProgramCategory" pc, "tbl_KeywordCategory" kc, "tbl_Keyword" k \
			WHERE (c."idChannel"=s."idChannel" AND s."idProgram"=p."idProgram" AND p."idCategory"=pc."idCategory" AND pc."idCategory"=kc."idCategory" AND k."idKeyword"=kc."idKeyword" AND s."startDate">current_timestamp AND k."keywordName"=\''+keyword+'\') \
			ORDER BY "startDate" LIMIT 1;'
		#query = 'SELECT "categoryName" FROM "tbl_ProgramCategory" pc, "tbl_KeywordCategory" kc, "tbl_Keyword" k WHERE (pc."idCategory"=kc."idCategory" AND k."idKeyword"=kc."idKeyword" AND k."keywordName"=\''+keyword+'\');'
		try:
			programs = db.readDB(query)
		except:
			return response
		i=0
		progArr = []
		while i<len(programs):
			channelNumber=programs[i][0]
			channelName=programs[i][1]
			startDate=str(programs[i][2])
			endDate=str(programs[i][3])
			title=programs[i][4]
			description=programs[i][5]
			mscName=programs[i][6]
			progArr.append({'channelNumber':channelNumber, 'channelName':channelName, 'startDate':startDate, 'endDate':endDate, 'title':title, 'description':description, 'mscName':mscName})
			i+=1
		response.append(progArr)
	return response

@route('/gnius/<user>/friends')
def userFriends(user=''):
	twitter = Twython()
	friends = twitter.getFriendsIDs(screen_name=user)["ids"]
	friend_list=''
	friends_bio=''
	i=0
	for friend in friends:
		friend_list += str(friend) + ','
		if((i+1)%100==0):
			aux = twitter.lookupUser(user_id=friend_list[:-1])
			for x in aux:
				try:
					friends_bio += x['description'].encode('ascii', 'replace')
				except:
					pass
			print friends_bio
			friend_list=''
			sleep(10)
		i+=1
	#for i in range(len(friends)):
	#	friend_list = friend_list + str(friends[i]) + ','
	#	print i, friend_list
	#	if((i+1)%100==0):
	#		aux = twitter.lookupUser(user_id=friend_list[:-1])
	#		print friend_list
	#		for x in range(100):
	#			print x
	#			friends_bio += aux[x]['description'].encode('ascii', 'replace')
	#			friends_bio += ' '
	#		sleep(5)
	#	friend_list=''
	#lookup = twitter.lookupUser(user_id=friend_list)
	return friends_bio
	#for friend in friends:
	#	lookup = twitter.lookupUser(userid=user)
	#	print lookup

@route('/gnius/<user>/bio')
def userBio(user=''):
	twitter = Twython()
	lookup = twitter.lookupUser(screen_name=user)
	lookup = lookup[0]['description'].encode('ascii', 'replace')#Extraer texto de Bio
	return tokenize(lookup)

@route('/gnius/<user>/TL')
def userTL(user=''):
	twitter = Twython()
	user_timeline = twitter.getUserTimeline(screen_name=user, count='200')
	all_tweets=''
	for tweet in user_timeline:
		text = tweet['text'].encode('ascii', 'replace')
		all_tweets +=' ' + text
	return tokenize(all_tweets)

@route('/gnius/kw')
def keywordsDB():
	db = DB(host='190.215.44.18', port='5432', dbname='GLF', user='postgres', password='$martb0xTv')
	query = 'SELECT "keywordName" FROM "tbl_Keyword";'
	keywords_db = db.readDB(query)
	keywords = [keyword[0].lower() for keyword in keywords_db]
	return keywords

def tokenize(text):
	lookup_t = nltk.word_tokenize(text)
	nltk.data.load('tokenizers/punkt/spanish.pickle')
	stops_es=stopwords.words('spanish')
	stops_en=stopwords.words('english')
	stops_custom = ['http']
	tokenized = [word.lower() for word in lookup_t if word not in stops_es and word not in stops_custom and word not in stops_en and word.isalpha() and len(word)>2]
	return tokenized

debug(True)
run(server='paste', host='192.168.56.1', port=8082, reloader=True)