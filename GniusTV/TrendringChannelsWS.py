#!C:\Python27

#bottle 
from bottle import route, run, debug, response

#TwiTV class
from twitv import TwiTv

import json

@route('/gnius/TC')
def trendingChannels():
	twitv = TwiTv()
	rank = twitv.channelRank()
	response = []
	i=0
	while i<len(rank):
		twits=rank[i][0]
		idChannel=rank[i][1]
		channelName=rank[i][2]
		channelNumber=str(rank[i][3])
		channelImage=rank[i][4]
		response.append({'twits':twits, 'idChannel':idChannel, 'channelName':channelName, 'channelNumber':channelNumber, 'channelImage':channelImage})
		i+=1
	return json.dumps({'response':response})

@route('/gnius/TC-list')
def trendingChannelsList():
	twitv = TwiTv()
	rank = twitv.channelRank()
	response = ''
	i=0
	while i<len(rank):
		twits=rank[i][0]
		idChannel=rank[i][1]
		channelName=rank[i][2]
		channelNumber=str(rank[i][3])
		channelImage=rank[i][4]
		response += '<tr><td>%s</td><td>%s</td><td>%s</td><td><img src="%s" /></td></tr>' % (idChannel, channelName, channelNumber, channelImage)
		i+=1
	response= '<table>' + response + '</table>'
	return response

debug(True)
run(server='paste', host='192.168.56.1', port=8082, reloader=True)