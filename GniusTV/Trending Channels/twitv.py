from sys import stdout
from db import DB
from psycopg2 import connect

class TwiTv:
	def __init__(self):
		pass
	def channelRank(self, idTimeSlice='SELECT last_value FROM "tbl_Timeslice_idTimeslice_seq"'):
		db=DB()
		query='SELECT count(*) "channelNewTwits", t."idChannel", c."channelName", c."channelNumber", c."channelImage" \
			FROM "tbl_Twit" t JOIN "tbl_Channel" c \
			ON t."idChannel" = c."idChannel" \
			JOIN "tbl_ChannelHashtag" ch \
			ON c."idChannel" = ch."idChannel" \
			AND ch."channelHastagEnabled"=TRUE \
			AND t."idTimeslice" = (%s)-1 \
			GROUP BY t."idChannel", c."channelName", c."channelNumber", c."channelImage" \
			ORDER BY "channelNewTwits" desc \
			LIMIT 10;' % (idTimeSlice)
		rank=db.readDB(query)
		i=0
		print '\n\n*********************'
		print '* Trending Channels *'
		print '*********************\n\n'
		while i<len(rank):
			twits=rank[i][0]
			idChannel=rank[i][1]
			channelName=rank[i][2]
			channelNumber=rank[i][3]
			print '%d) %s %s' % (i+1, channelName, channelNumber)
			i+=1
		print '\n\n'
		return rank

	def hashtags(self):
		db=DB()
		#Query definition
		query = 'SELECT c."idChannel", c."channelNumber", c."channelName", ch."channelHashtagText" \
		FROM "tbl_Channel" c JOIN "tbl_ChannelHashtag" ch \
		ON c."idChannel"=ch."idChannel";'
		registros=db.readDB(query)

		#Local Array
		hashTags=[]

		#Reorganize DB response
		i=0
		add=1
		while i<len(registros):
			idChannel=registros[i][0]
			channelNumber=registros[i][1]
			channelName=registros[i][2]
			ht=registros[i][3]
			if registros[i][0]==registros[i-1][0] and i!=0:
				row.append(registros[i][3])
				add=0
			else:
				row = [i, idChannel, channelNumber, channelName, ht]
				add=1
			if add:
				hashTags.append(row)
			i+=1
		return hashTags

	def newTimeSlice(self):
		db=DB()
		query='INSERT INTO "tbl_TimeSlice" ("timeSliceDateFrom", "timeSliceTimeFrom") VALUES (current_date, current_time);'
		db.doDB(query)
		query='SELECT last_value FROM "tbl_Timeslice_idTimeslice_seq";'
		idTimeSlice=db.readDB(query)[0][0]
		return idTimeSlice

	def lastTwit(self, hashTags):
		db=DB()
		query='SELECT "twitTwitId" FROM "tbl_Twit" WHERE "idChannel"=%d ORDER BY "idTwit" desc LIMIT 1;' % hashTags[1]
		lastTwit = db.readDB(query)
		try:
			lastTwit = lastTwit[0][0]
		except:
			lastTwit = ""
		lastTwit = str(lastTwit)
		return lastTwit

def sprint(*text):
	text = ' '.join(text)
	stdout.write(text)
	stdout.flush()
