from psycopg2 import connect

#Clase de coneccion a PostgreSQL

class DB:
	def __init__(self, host='', port='', dbname='', user='', password=''):
		self.host=host
		self.port=port
		self.dbname=dbname
		self.user=user
		self.password=password
		if self.host=='' and self.port=='' and self.dbname=='' and self.user=='' and self.password=='':
			self.host='190.215.44.18'
			self.port='5432'
			self.dbname='GLF'
			self.user='postgres'
			self.password='$martb0xTv'

	#vars: imprime en pantalla los parametros de coneccion seteados en el objeto
	def vars(self):
		print 'host: ', self.host
		print 'port: ', self.port
		print 'dbname: ', self.dbname
		print 'user: ', self.user
		print 'password: ', self.password

	#doDB: ejecutar una query en DB
	def doDB(self, query):
		#Connect action
		conexion = connect("dbname="+self.dbname+" port="+self.port+" host="+self.host+" user="+self.user+" password="+self.password)
		cursor = conexion.cursor()
		#Query execution
		try:
			cursor.execute(query)
		except Exception, e:
			print "Unexpected error:", sys.exc_info()[0]
		conexion.commit()
		cursor.close()
		conexion.close()
		return cursor

	#readDB: leer desde DB
	def readDB(self, query):
		#Connect action
		conexion = connect("dbname="+self.dbname+" port="+self.port+" host="+self.host+" user="+self.user+" password="+self.password)
		cursor = conexion.cursor()
		#Query execution
		cursor.execute(query)
		#cursor = self.doDB(query)
		registros = cursor.fetchall()
		#cursor.close()
		conexion.close()
		return registros