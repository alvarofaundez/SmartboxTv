#!C:\Python27

from twython import Twython
from time import sleep
from twitv import TwiTv, sprint
from db import DB
from datetime import timedelta, datetime
import sys

db = DB()
twitv = TwiTv()
twitter = Twython()

#Condition to keep this loop running forever
while True:
	hashTags=twitv.hashtags()
	#Crear nuevo TimeSlice
	idTimeSlice=twitv.newTimeSlice()
	i=0
	while i<len(hashTags):
		limit = twitv.lastTwit(hashTags[i])
		ht = ' OR '.join(hashTags[i][4:])
		twitterRequest = ht
		channelNumber=hashTags[i][2]
		channelName=hashTags[i][3]
		sprint(str(channelNumber), channelName)
		try:
			search_results = twitter.search(since_id=limit, q=twitterRequest, rpp="100")
		except:
			print " Error en el Request a Twitter"
			#print search_results
		try:
			search_results["results"].reverse()
			#Insertar Tweets a la BD
			for tweet in search_results["results"]:
				twitTwitId = tweet['id']
				twitOwnerUsername = tweet['from_user'].encode('utf-8')
				#twitGeoLat = tweet['geo']
				twitCreatedDateTime = datetime.strptime(tweet['created_at'][5:-6], '%d %b %Y %H:%M:%S') - timedelta(hours=4)
				twitCreatedDate = twitCreatedDateTime.strftime('%d-%b-%Y')
				twitCreatedTime = twitCreatedDateTime.strftime('%H:%M:%S')
				twitHashtagsUsed = ','.join(hashTags[i][4:])
				twitText = tweet['text'].replace("'", ' ')
				#twitGeoLong = tweet['geo']
				idChannel = hashTags[i][1]
				#print "Tweet from @%s" % twitOwnerUsername
				#print "At: %s %s" % (twitCreatedDate, twitCreatedTime)
				#print twitText,"\n"
				queryFormat = 'INSERT INTO "tbl_Twit"("idTimeslice", "idChannel", "twitTwitId", "twitOwnerUsername", "twitCreatedDate", "twitCreatedTime", "twitHashtagsUsed", "twitText") VALUES (%d, %d, \'%s\', \'%s\', \'%s\', \'%s\', \'%s\', \'%s\');'
				queryValues = (idTimeSlice, idChannel, twitTwitId, twitOwnerUsername, twitCreatedDate, twitCreatedTime, twitHashtagsUsed, twitText)
				query = queryFormat % queryValues
				try:
					db.doDB(query)
				except Exception, e:
					print "Error al guardar twit."
					print "ID: %s" % (twitTwitId)
					print "@%s" % (twitOwnerUsername)
					print "At: %s %s" % (twitCreatedDate, twitCreatedTime)
					print "HT: %s" % (twitHashtagsUsed)
					print "%s" % (twitText)
					print "Unexpected error:", sys.exc_info()[0]
				sprint('.')
		except Exception, e:
			print "Unexpected error:", sys.exc_info()[0]
			#print search_results["results"]
		sprint(' done!\n')
		sleep(5)
		i+=1
	twitv.channelRank(idTimeSlice)
	sleep(20)