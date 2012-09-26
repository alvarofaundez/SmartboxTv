#!C:\Python27

from twython import Twython
#import nltk.data
#from nltk.tokenize import TreebankWordTokenizer
import nltk
#from nltk import *
from bottle import route, run, debug
import simplejson as json
from nltk.corpus import stopwords
from collections import Counter

@route('/gnius/<user>')
def gnius(user='rafalopezpo'):
	nltk.data.load('tokenizers/punkt/spanish.pickle')
	stops_es=stopwords.words('spanish')
	stops_en=stopwords.words('english')

	twitter = Twython()
	#user=raw_input('user: ')
	print '\nUser Description\n\n'
	lookup = twitter.lookupUser(screen_name=user)
	lookup = lookup[0]['description'].encode('ascii', 'replace')
	lookup_t = nltk.word_tokenize(lookup)
	stops_custom = ['http']
	cleaned_lookup = [word.lower() for word in lookup_t if word not in stops_es and word not in stops_custom and word not in stops_en and word.isalpha() and len(word)>2]
	print cleaned_lookup
	print '\nUser Timeline\n\n'
	# We won't authenticate for this, but sometimes it's necessary
	user_timeline = twitter.getUserTimeline(screen_name=user, count='200')
	all_tweets=''
	for tweet in user_timeline:
		text = tweet['text'].encode('ascii', 'replace')
		all_tweets +=' ' + text 
	#print '\nTexto\n\n%s' % (all_tweets)
	all_tweets_t = nltk.word_tokenize(all_tweets)
	cleaned_tweets = [word.lower() for word in all_tweets_t if word not in stops_es and word not in stops_custom and word not in stops_en and word.isalpha() and len(word)>2]
	print '\nTokens\n'
	print cleaned_tweets
	c = Counter(cleaned_tweets)
	print '\nCommon terms\n'
	t=c.most_common(5)
	d={}
	for x in t:
		d[]
	j=json.dumps(d)
	print j
	#t=nltk.Text(cleaned_tweets)
	#t=({'user':user})
	return j
debug(True)
run(server='paste', host='192.168.1.156', port=8082, reloader=True)
#print 'Plot terms'
#terms=[]
#while True:
#	term=raw_input('term: ')
#	if term != '':
#		terms.append(term)
#	else:
#		break
#t.dispersion_plot(terms)
#for word in corpora_t:
#	print word, corpora.count(word)