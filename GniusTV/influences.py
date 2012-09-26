#!C:\Python27
from pyklout import Klout

api = Klout('acbxt9d2p52vmgvv2u38nrba')
username = raw_input('Twitter username: ')

#User identification
try:
	user = api.identity(username, 'twitter')
except Exception, e:
	print 'Can\'t find the user %s:\n%s' % (username,e)
	exit()
user_id = user['id']

#User score
try:
	score = api.score(user_id)
except Exception, e:
	print 'Can\'t get the score of %s:\n%s' % (username,e)
	exit()
print 'User score: %f' % (score['score'])

#User influences
try:
	data = api.influences(user_id)
except Exception, e:
	print 'Can\'t get influencers of %s:\n%s' % (username,e)
	exit()
print '\nInfluencers\n'
for x in data['myInfluencers']:
	nick = x['entity']['payload']['nick']
	score = x['entity']['payload']['score']['score']
	print '%s %f' % (nick, score)

#User topics
try:
	data = api.topics(user_id)
except Exception, e:
	print 'Can\'t get topics of %s:\n%s' % (username,e)
	exit()
print '\nTop topics\n'
for x in data:
	topic = x['displayName']
	print topic