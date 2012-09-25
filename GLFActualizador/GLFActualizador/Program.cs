using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Xml;
using DTOLayer;
using ConnectionLayer;
using System.Collections;

namespace GLFActualizador
{
    class Program
    {


        static GLFDatabaseConnection conexion = new GLFDatabaseConnection();
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            string file = fileName();            
            downloadFile(file);
            doc.Load((Directory.GetCurrentDirectory() + "\\Movistar\\" + file).Replace(".gz",".xml"));

            InsertRole(doc);
            InsertActor(doc);
            InsertType(doc);
            InsertChannel(doc);
            InsertCategories(doc);
            InsertProgramValues(doc);
            InsertProgramFlags(doc);
            InsertPrograms(doc);
            InsertScheduleValues(doc);
            InsertScheduleFlags(doc);
            InsertSchedule(doc);
        }

        static String fileName()
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://ftp1.tmstv.com/pub/");
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("chsante", "tel37ile");

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            List<string> lines = new List<string>();
            string name;
            while ((name = reader.ReadLine()) != null)//read textreader variable line by line
            {
                if (!name.Contains("new"))
                    lines.Add(name);
            }

            Char[] separador = new Char[1];
            separador[0] = ' ';
            String[] arreglo = lines[lines.Count - 1].Split(separador);

            //Console.WriteLine(reader.ReadToEnd());

            //Console.WriteLine("Download Complete, status {0}", response.StatusDescription);

            reader.Close();
            response.Close();

            return arreglo[arreglo.Count() - 1];
        }

        static void downloadFile(String name)
        {
            if(!Directory.Exists(Directory.GetCurrentDirectory() + "\\Movistar"))
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Movistar");

            WebClient request = new WebClient();
            
            request.Credentials = new NetworkCredential("chsante", "tel37ile");
            byte[] fileData = request.DownloadData("ftp://ftp1.tmstv.com/pub/" + name);

            if (!File.Exists(Directory.GetCurrentDirectory() + "\\Movistar\\" + name))
            {
                FileStream file = File.Create(Directory.GetCurrentDirectory() + "\\Movistar\\" + name);
                file.Write(fileData, 0, fileData.Length);
                file.Close();
            }
            DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\Movistar");

            foreach (FileInfo fi in di.GetFiles("*.gz"))
            {
                if(fi.Name==name)
                    Decompress(fi);
            }

        }

        public static void Decompress(FileInfo fi)
        {
            // Get the stream of the source file.
            using (FileStream inFile = fi.OpenRead())
            {
                // Get original file extension, for example
                // "doc" from report.doc.gz.
                string curFile = fi.FullName;
                string origName = curFile.Remove(curFile.Length -
                        fi.Extension.Length);

                //Create the decompressed file.
                using (FileStream outFile = File.Create(origName+".xml"))
                {
                    using (GZipStream Decompress = new GZipStream(inFile,
                            CompressionMode.Decompress))
                    {
                        // Copy the decompression stream 
                        // into the output file.
                        Decompress.CopyTo(outFile);

                        Console.WriteLine("Decompressed: {0}", fi.Name);
                    }
                }
            }
        }

        static void InsertType(XmlDocument xmlDoc)
        {
            try
            {
                Console.WriteLine("Tipo de Canales");
                DTOType tipo = new DTOType();
                XmlNodeList channels = xmlDoc.GetElementsByTagName("glf")[0].ChildNodes[2].ChildNodes;
                
                foreach (XmlNode channel in channels)
                {
                    tipo.Type = channel.Attributes["t"].Value;
                    conexion.AgregarTipos(tipo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void InsertChannel(XmlDocument xmlDoc)
        {
            try
            {
                Console.WriteLine("Canales");
                DTOChannel canal = new DTOChannel();
                XmlNodeList channels = xmlDoc.GetElementsByTagName("glf")[0].ChildNodes[2].ChildNodes;

                foreach (XmlNode channel in channels)
                {
                    canal.IdChannel = Int64.Parse(channel.Attributes["id"].Value);
                    canal.CallLetter = channel.Attributes["c"].Value;
                    canal.ChannelName = channel.Attributes["l"].Value;
                    conexion.AgregarCanal(canal, channel.Attributes["t"].Value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void InsertCategories(XmlDocument xmlDoc)
        {
            try
            {
                Console.WriteLine("Categoria de Programas");
                DTOCategory categoria = new DTOCategory();
                XmlNodeList categories = xmlDoc.GetElementsByTagName("glf")[0].ChildNodes[0].ChildNodes[5].ChildNodes;
                int i = categories.Count;
                int j = 0;
                foreach (XmlNode category in categories)
                {
                    categoria.IdCategory = Int64.Parse(category.Attributes["id"].Value);
                    categoria.MscName = category.Attributes["mscname"].Value;
                    categoria.CategoryName = category.Attributes["value"].Value;
                    categoria.IdFather = 0;
                    conexion.AgregarCategoria(categoria);
                    foreach (XmlNode subCategory in category.ChildNodes)
                    {
                        categoria.IdCategory = Int64.Parse(subCategory.Attributes["id"].Value);
                        categoria.MscName = subCategory.Attributes["mscname"].Value;
                        categoria.CategoryName = subCategory.Attributes["value"].Value;
                        categoria.IdFather = Int64.Parse(category.Attributes["id"].Value);
                        conexion.AgregarCategoria(categoria);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void InsertProgramValues(XmlDocument doc)
        {
            try
            {
                Console.WriteLine("Valor de Programas");
                DTOProgramValue valor = new DTOProgramValue();
                XmlNodeList programValues = doc.GetElementsByTagName("glf")[0].ChildNodes[0].ChildNodes[6].ChildNodes;

                foreach (XmlNode value in programValues)
                {
                    valor.IdProgramValue = Int64.Parse(value.Attributes["id"].Value);
                    valor.Name = value.Attributes["name"].Value;
                    valor.Pname = value.Attributes["pname"].Value;
                    valor.Description = value.Attributes["desc"].Value;
                    conexion.AgregarValorPrograma(valor);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void InsertProgramFlags(XmlDocument doc)
        {
            try
            {
                Console.WriteLine("Marca de Programas");
                DTOProgramFlag marca = new DTOProgramFlag();
                XmlNodeList programFlags = doc.GetElementsByTagName("glf")[0].ChildNodes[0].ChildNodes[3].ChildNodes;

                foreach (XmlNode flag in programFlags)
                {
                    marca.IdProgramFlag = Int64.Parse(flag.Attributes["id"].Value);
                    marca.Name = flag.Attributes["name"].Value;
                    marca.Pname = flag.Attributes["pname"].Value;
                    marca.Description = flag.Attributes["desc"].Value;
                    conexion.AgregarMarcaPrograma(marca);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void InsertPrograms(XmlDocument doc)
        {
            try
            {
                Console.WriteLine("Programas");
                DTOProgram programa = new DTOProgram();
                DTOProgramActorRole par = new DTOProgramActorRole();
                XmlNodeList programs = doc.GetElementsByTagName("glf")[0].ChildNodes[0].ChildNodes[1].ChildNodes;
                int i = programs.Count;
                int j = 0;
                foreach (XmlNode program in programs)
                {
                    programa.IdProgram = Int64.Parse(program.Attributes["id"].Value);
                    if (program.Attributes["t"] != null)
                        programa.Title = program.Attributes["t"].Value;
                    else
                        programa.Title = "";
                    if (program.Attributes["rt"] != null)
                        programa.RTitle = program.Attributes["rt"].Value;
                    else
                        programa.RTitle = "";
                    if (program.Attributes["d"] != null)
                        programa.Description = program.Attributes["d"].Value;
                    else
                        programa.Description = "";
                    if (program.Attributes["rd"] != null)
                        programa.RDescription = program.Attributes["rd"].Value;
                    else
                        programa.RDescription = "";
                    if (program.Attributes["et"] != null)
                        programa.EpisodeTitle = program.Attributes["et"].Value;
                    else
                        programa.EpisodeTitle = "";

                    XmlNode category = buscarCategoria(program);
                    if (category != null)
                        programa.IdCategory = Int64.Parse(category.Attributes["id"].Value);
                    else
                        programa.IdCategory = 0;

                    conexion.AgregarPrograma(programa);

                    ArrayList roles = buscarRole(program);

                    foreach (XmlNode role in roles)
                    {
                        par.IdProgram = programa.IdProgram;
                        par.IdActor = Int32.Parse(role.Attributes["n"].Value);
                        par.IdRole = Int32.Parse(role.Attributes["r"].Value);
                        par.Order = Int32.Parse(role.Attributes["o"].Value);
                        conexion.AgregarProgramaActorRole(par);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void InsertScheduleValues(XmlDocument doc)
        {
            try
            {
                Console.WriteLine("Valor de Horarios");
                DTOScheduleValue valor = new DTOScheduleValue();
                XmlNodeList scheduleValues = doc.GetElementsByTagName("glf")[0].ChildNodes[0].ChildNodes[7].ChildNodes;

                foreach (XmlNode value in scheduleValues)
                {
                    valor.IdScheduleValue = Int64.Parse(value.Attributes["id"].Value);
                    valor.Name = value.Attributes["name"].Value;
                    valor.Pname = value.Attributes["pname"].Value;
                    valor.Description = value.Attributes["desc"].Value;
                    conexion.AgregarValorHorario(valor);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void InsertScheduleFlags(XmlDocument doc)
        {
            try
            {
                Console.WriteLine("Marca de Horarios");
                DTOScheduleFlag marca = new DTOScheduleFlag();
                XmlNodeList scheduleFlags = doc.GetElementsByTagName("glf")[0].ChildNodes[0].ChildNodes[3].ChildNodes;

                foreach (XmlNode flag in scheduleFlags)
                {
                    marca.IdScheduleFlag = Int64.Parse(flag.Attributes["id"].Value);
                    marca.Name = flag.Attributes["name"].Value;
                    marca.Pname = flag.Attributes["pname"].Value;
                    marca.Description = flag.Attributes["desc"].Value;
                    conexion.AgregarMarcaHorario(marca);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void InsertSchedule(XmlDocument doc)
        {
            try
            {
                Console.WriteLine("Limpiando Horario");
                //conexion.LimpiarHorario();
                Console.WriteLine("Horario");
                DTOSchedule schedule = new DTOSchedule();
                XmlNodeList schedules = doc.GetElementsByTagName("glf")[0].ChildNodes[0].ChildNodes[0].ChildNodes;

                foreach (XmlNode s in schedules)
                {
                    schedule.StartDate = DateTime.Parse(s.Attributes["s"].Value).ToLocalTime();
                    schedule.EndDate = endDateString(schedule.StartDate, Int32.Parse(s.Attributes["d"].Value));
                    schedule.IdProgram = Int64.Parse(s.Attributes["p"].Value);
                    schedule.IdChannel = Int64.Parse(s.Attributes["c"].Value);
                    conexion.AgregarHorario(schedule);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void InsertRole(XmlDocument doc)
        {
            try
            {
                Console.WriteLine("Roles");
                DTORole role = new DTORole();
                XmlNodeList roles = doc.ChildNodes[3].ChildNodes[0].ChildNodes[2].ChildNodes[0].ChildNodes;

                foreach (XmlNode r in roles)
                {
                    role.IdRole = Int64.Parse(r.Attributes["id"].Value);
                    role.Title = r.Attributes["title"].Value;
                    role.Description = r.Attributes["desc"].Value;
                    conexion.AgregarRole(role);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void InsertActor(XmlDocument doc)
        {
            try
            {
                Console.WriteLine("Actores");
                DTOActor actor = new DTOActor();
                XmlNodeList actors = doc.ChildNodes[3].ChildNodes[0].ChildNodes[2].ChildNodes[1].ChildNodes;

                foreach (XmlNode n in actors)
                {
                    actor.IdActor = Int64.Parse(n.Attributes["id"].Value);
                    actor.FirstName = n.Attributes["fname"].Value;
                    actor.LastName = n.Attributes["lname"].Value;
                    conexion.AgregarActor(actor);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static DateTime endDateString(DateTime date, int duracion)
        {
            int minutos = duracion / 60;
            TimeSpan sumas = new TimeSpan(0, minutos, 0);
            DateTime final = date.Add(sumas);
            return final;
        }

        static XmlNode buscarCategoria(XmlNode nodo)
        {
            XmlNode categoria = null;
            foreach (XmlNode valor in nodo)
            {
                if (valor.Name == "c")
                    categoria = valor;
            }
            return categoria;
        }

        static ArrayList buscarRole(XmlNode nodo)
        {
            ArrayList roles = new ArrayList();
            foreach (XmlNode valor in nodo)
            {
                if (valor.Name == "r")
                    roles.Add(valor);
            }
            return roles;
        }
    }
}
