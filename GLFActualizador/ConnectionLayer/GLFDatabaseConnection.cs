using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTOLayer;
using System.Data.SqlClient;
using System.Data;
using Npgsql;

namespace ConnectionLayer
{
    public class GLFDatabaseConnection
    {
        static String sConexion = "Server=190.215.44.18;Port=5432;User Id=postgres;Password=$martb0xTv;Database=GLF";
        public GLFDatabaseConnection()
        {
            //this.sConexion = "Server=190.215.44.18;Port=5432;User Id=postgres;Password=$martb0xTv;Database=GLF";
        }

        public void AgregarTipos(DTOType tipo)
        {
            string sSel;
            string sSelCount;
            bool exist;

            sSelCount = "SELECT COUNT (*) FROM \"tbl_ChannelType\" ct WHERE ct.\"channelType\"='"+ tipo.Type +"'";
            NpgsqlDataAdapter daCount;
            DataSet dtCount = new DataSet();
            try
            {
                daCount = new NpgsqlDataAdapter(sSelCount, sConexion);
                daCount.Fill(dtCount);
                if (dtCount.Tables[0].Rows[0][0].ToString() == "0")
                    exist = false;
                else
                    exist = true;
            }
            catch (Exception)
            {
                exist = false;
            }
            if (!exist)
            {
                sSel = "INSERT INTO \"tbl_ChannelType\"(\"channelType\") VALUES('" + tipo.Type + "');";

                NpgsqlDataAdapter da;
                DataSet dt = new DataSet();

                try
                {
                    da = new NpgsqlDataAdapter(sSel, sConexion);
                    da.Fill(dt);
                }
                catch (Exception)
                {

                }
            }
        }

        public void AgregarCanal(DTOChannel channel, String type)
        {
            string sSel;
            string sSelCount;
            bool exist;

            sSelCount = "SELECT COUNT(*) FROM \"tbl_Channel\" WHERE \"idChannel\"=" + channel.IdChannel;
            NpgsqlDataAdapter daCount;
            DataSet dtCount = new DataSet();
            try
            {
                daCount = new NpgsqlDataAdapter(sSelCount, sConexion);
                daCount.Fill(dtCount);
                if (dtCount.Tables[0].Rows[0][0].ToString() == "0")
                    exist = false;
                else
                    exist = true;
            }
            catch (Exception)
            {
                exist = false;
            }


            if (!exist)
            {
                string sSelIdTipo = "SELECT \"tbl_ChannelType\".\"idType\" FROM \"tbl_ChannelType\" WHERE \"tbl_ChannelType\".\"channelType\" = '" + type + "'";
                NpgsqlDataAdapter daIdTipo;
                DataSet dtIdTipo = new DataSet();
                string idTipo="";
                try
                {
                    daIdTipo = new NpgsqlDataAdapter(sSelIdTipo, sConexion);
                    daIdTipo.Fill(dtIdTipo);
                    idTipo = dtIdTipo.Tables[0].Rows[0][0].ToString();
                }
                catch (Exception)
                {

                }

                sSel = "INSERT INTO \"tbl_Channel\" VALUES(" + channel.IdChannel + ",'" + channel.CallLetter + "','" + channel.ChannelName.Replace("'","") + "'," + idTipo + ");";

                NpgsqlDataAdapter da;
                DataSet dt = new DataSet();

                try
                {
                    da = new NpgsqlDataAdapter(sSel, sConexion);
                    da.Fill(dt);
                }
                catch (Exception)
                {

                }
            }
        }

        public void AgregarCategoria(DTOCategory category)
        {
            string sSel;
            string sSelCount;
            bool exist;
            sSelCount = "SELECT COUNT(*) FROM \"tbl_ProgramCategory\" WHERE \"idCategory\"=" + category.IdCategory + "";
            NpgsqlDataAdapter daCount;
            DataSet dtCount = new DataSet();
            try
            {
                daCount = new NpgsqlDataAdapter(sSelCount, sConexion);
                daCount.Fill(dtCount);
                if (dtCount.Tables[0].Rows[0][0].ToString() == "0")
                    exist = false;
                else
                    exist = true;
            }
            catch (Exception)
            {
                exist = false;
            }
            if (!exist)
            {
                if (category.IdFather != 0)
                    sSel = "INSERT INTO \"tbl_ProgramCategory\" VALUES(" + category.IdCategory + ",'" + category.MscName + "','" + category.CategoryName + "'," + category.IdFather + ");";
                else
                    sSel = "INSERT INTO \"tbl_ProgramCategory\" VALUES(" + category.IdCategory + ",'" + category.MscName + "','" + category.CategoryName + "',-1)";

                NpgsqlDataAdapter da;
                DataSet dt = new DataSet();

                try
                {
                    da = new NpgsqlDataAdapter(sSel, sConexion);
                    da.Fill(dt);
                }
                catch (Exception)
                {

                }
            }
            
        }

        public void AgregarValorPrograma(DTOProgramValue value)
        {
            string sSel;
            string sSelCount;
            bool exist;
            sSelCount = "SELECT COUNT(*) FROM \"tbl_ProgramValue\" WHERE \"idProgramValue\" = " + value.IdProgramValue;
            NpgsqlDataAdapter daCount;
            DataSet dtCount = new DataSet();
            try
            {
                daCount = new NpgsqlDataAdapter(sSelCount, sConexion);
                daCount.Fill(dtCount);
                if (dtCount.Tables[0].Rows[0][0].ToString() == "0")
                    exist = false;
                else
                    exist = true;
            }
            catch (Exception)
            {
                exist = false;
            }
            if (!exist)
            {
                sSel = "INSERT INTO \"tbl_ProgramValue\" VALUES(" + value.IdProgramValue + ",'" + value.Name + "','" + value.Pname + "','" + value.Description + "')";

                NpgsqlDataAdapter da;
                DataSet dt = new DataSet();

                try
                {
                    da = new NpgsqlDataAdapter(sSel, sConexion);
                    da.Fill(dt);
                }
                catch (Exception)
                {

                }
            }
        }

        public void AgregarMarcaPrograma(DTOProgramFlag flag)
        {
            string sSel;
            string sSelCount;
            bool exist;
            sSelCount = "SELECT COUNT(*) FROM \"tbl_ProgramFlag\" WHERE \"idProgramFlag\" = " + flag.IdProgramFlag;
            NpgsqlDataAdapter daCount;
            DataSet dtCount = new DataSet();
            try
            {
                daCount = new NpgsqlDataAdapter(sSelCount, sConexion);
                daCount.Fill(dtCount);
                if (dtCount.Tables[0].Rows[0][0].ToString() == "0")
                    exist = false;
                else
                    exist = true;
            }
            catch (Exception)
            {
                exist = false;
            }
            if (!exist)
            {
                sSel = "INSERT INTO \"tbl_ProgramFlag\" VALUES(" + flag.IdProgramFlag + ",'" + flag.Name + "','" + flag.Pname + "','" + flag.Description + "')";

                NpgsqlDataAdapter da;
                DataSet dt = new DataSet();

                try
                {
                    da = new NpgsqlDataAdapter(sSel, sConexion);
                    da.Fill(dt);
                }
                catch (Exception)
                {

                }
            }
        }

        public void AgregarPrograma(DTOProgram program)
        {
            string sSel;
            string sSelCount;
            bool exist;
            sSelCount = "SELECT COUNT(*) FROM \"tbl_Program\" WHERE \"idProgram\"=" + program.IdProgram;
            NpgsqlDataAdapter daCount;
            DataSet dtCount = new DataSet();
            try
            {
                daCount = new NpgsqlDataAdapter(sSelCount, sConexion);
                daCount.Fill(dtCount);
                if (dtCount.Tables[0].Rows[0][0].ToString() == "0")
                    exist = false;
                else
                    exist = true;
            }
            catch (Exception)
            {
                exist = false;
            }
            if (!exist)
            {
                sSel = "INSERT INTO \"tbl_Program\" VALUES("+ program.IdProgram;
                if (program.Title != "")
                    sSel = sSel + ",'" + program.Title.Replace("'","") + "'";
                else
                    sSel = sSel + ",NULL";

                if (program.RTitle != "")
                    sSel = sSel + ",'" + program.RTitle.Replace("'", "") + "'";
                else
                    sSel = sSel + ",NULL";

                if (program.Description != "")
                    sSel = sSel + ",'" + program.Description.Replace("'", "") + "'";
                else
                    sSel = sSel + ",NULL";

                if (program.RDescription != "")
                    sSel = sSel + ",'" + program.RDescription.Replace("'", "") + "'";
                else
                    sSel = sSel + ",NULL";

                if (program.EpisodeTitle != "")
                    sSel = sSel + ",'" + program.EpisodeTitle.Replace("'", "") + "'";
                else
                    sSel = sSel + ",NULL";

                if (program.IdCategory != 0)
                    sSel = sSel + "," + program.IdCategory+");";
                else
                    sSel = sSel + ",NULL);";

                NpgsqlDataAdapter da;
                DataSet dt = new DataSet();

                try
                {
                    da = new NpgsqlDataAdapter(sSel, sConexion);
                    da.Fill(dt);
                }
                catch (Exception)
                {

                }
            }
        }

        public void AgregarValorHorario(DTOScheduleValue value)
        {
            string sSel;
            string sSelCount;
            bool exist;
            sSelCount = "SELECT COUNT(*) FROM \"tbl_ScheduleValue\" WHERE \"idScheduleValue\" = " + value.IdScheduleValue;
            NpgsqlDataAdapter daCount;
            DataSet dtCount = new DataSet();
            try
            {
                daCount = new NpgsqlDataAdapter(sSelCount, sConexion);
                daCount.Fill(dtCount);
                if (dtCount.Tables[0].Rows[0][0].ToString() == "0")
                    exist = false;
                else
                    exist = true;
            }
            catch (Exception)
            {
                exist = false;
            }
            if (!exist)
            {
                sSel = "INSERT INTO \"tbl_ScheduleValue\" VALUES("+ value.IdScheduleValue +",'"+ value.Name +"','"+ value.Pname +"','"+ value.Description +"')";

                NpgsqlDataAdapter da;
                DataSet dt = new DataSet();

                try
                {
                    da = new NpgsqlDataAdapter(sSel, sConexion);
                    da.Fill(dt);
                }
                catch (Exception)
                {

                }
            }
        }

        public void AgregarMarcaHorario(DTOScheduleFlag flag)
        {
            string sSel;
            string sSelCount;
            bool exist;
            sSelCount = "SELECT COUNT(*) FROM \"tbl_ScheduleFlag\" WHERE \"idScheduleFlag\" = " + flag.IdScheduleFlag;
            NpgsqlDataAdapter daCount;
            DataSet dtCount = new DataSet();
            try
            {
                daCount = new NpgsqlDataAdapter(sSelCount, sConexion);
                daCount.Fill(dtCount);
                if (dtCount.Tables[0].Rows[0][0].ToString() == "0")
                    exist = false;
                else
                    exist = true;
            }
            catch (Exception)
            {
                exist = false;
            }
            if (!exist)
            {
                sSel = "INSERT INTO \"tbl_ScheduleFlag\" VALUES("+ flag.IdScheduleFlag +",'"+ flag.Name +"','"+ flag.Pname +"','"+ flag.Description +"')";

                NpgsqlDataAdapter da;
                DataSet dt = new DataSet();

                try
                {
                    da = new NpgsqlDataAdapter(sSel, sConexion);
                    da.Fill(dt);
                }
                catch (Exception)
                {

                }
            }
        }

        public void AgregarHorario(DTOSchedule schedule)
        {
            string sSel;
            string sSelCount;
            bool exist;
            sSelCount = "SELECT COUNT(*) FROM \"tbl_Schedule\" WHERE \"startDate\" = '" + schedule.StartDate + "' AND \"endDate\"='"+ schedule.EndDate +"' AND \"idChannel\" = " + schedule.IdChannel;
            NpgsqlDataAdapter daCount;
            DataSet dtCount = new DataSet();
            try
            {
                daCount = new NpgsqlDataAdapter(sSelCount, sConexion);
                daCount.Fill(dtCount);
                if (dtCount.Tables[0].Rows[0][0].ToString() == "0")
                    exist = false;
                else
                    exist = true;
            }
            catch (Exception)
            {
                exist = false;
            }
            if (!exist)
            {
                sSel = "INSERT INTO \"tbl_Schedule\"(\"startDate\",\"endDate\",\"idProgram\",\"idChannel\") VALUES('" + schedule.StartDate + "','" + schedule.EndDate + "'," + schedule.IdProgram + "," + schedule.IdChannel + ")";

                NpgsqlDataAdapter da;
                DataSet dt = new DataSet();

                try
                {
                    da = new NpgsqlDataAdapter(sSel, sConexion);
                    da.Fill(dt);
                }
                catch (Exception)
                {

                }
            }
            else if (exist)
            {
                sSel = "UPDATE \"tbl_Schedule\" SET \"idProgram\" = " + schedule.IdProgram + " WHERE \"startDate\"='"+ schedule.StartDate +"' AND \"endDate\"='"+ schedule.EndDate +"' AND \"idChannel\"=" + schedule.IdChannel;

                NpgsqlDataAdapter da;
                DataSet dt = new DataSet();

                try
                {
                    da = new NpgsqlDataAdapter(sSel, sConexion);
                    da.Fill(dt);
                }
                catch (Exception)
                {

                }
            }
        }

        public void AgregarRole(DTORole role)
        {
            string sSel;
            string sSelCount;
            bool exist;
            sSelCount = "SELECT COUNT(*) FROM \"tbl_Role\" WHERE \"idRole\" = " + role.IdRole + ";";
            NpgsqlDataAdapter daCount;
            DataSet dtCount = new DataSet();
            try
            {
                daCount = new NpgsqlDataAdapter(sSelCount, sConexion);
                daCount.Fill(dtCount);
                if (dtCount.Tables[0].Rows[0][0].ToString() == "0")
                    exist = false;
                else
                    exist = true;
            }
            catch (Exception)
            {
                exist = false;
            }
            if (!exist)
            {
                sSel = "INSERT INTO \"tbl_Role\" VALUES(" + role.IdRole + ",'" + role.Title + "','" + role.Description + "');";

                NpgsqlDataAdapter da;
                DataSet dt = new DataSet();

                try
                {
                    da = new NpgsqlDataAdapter(sSel, sConexion);
                    da.Fill(dt);
                }
                catch (Exception)
                {

                }
            }
        }

        public void AgregarActor(DTOActor actor)
        {
            string sSel;
            string sSelCount;
            bool exist;
            sSelCount = "SELECT COUNT(*) FROM \"tbl_Actor\" WHERE \"idActor\" = " + actor.IdActor + ";";
            NpgsqlDataAdapter daCount;
            DataSet dtCount = new DataSet();
            try
            {
                daCount = new NpgsqlDataAdapter(sSelCount, sConexion);
                daCount.Fill(dtCount);
                if (dtCount.Tables[0].Rows[0][0].ToString() == "0")
                    exist = false;
                else
                    exist = true;
            }
            catch (Exception)
            {
                exist = false;
            }
            if (!exist)
            {
                sSel = "INSERT INTO \"tbl_Actor\" VALUES(" + actor.IdActor + ",'" + actor.FirstName + "','" + actor.LastName + "');";

                NpgsqlDataAdapter da;
                DataSet dt = new DataSet();

                try
                {
                    da = new NpgsqlDataAdapter(sSel, sConexion);
                    da.Fill(dt);
                }
                catch (Exception)
                {

                }
            }
        }

        public void AgregarProgramaActorRole(DTOProgramActorRole par)
        {
            string sSel;
            string sSelCount;
            bool exist;
            sSelCount = "SELECT COUNT(*) FROM \"tbl_ProgramActorRole\" WHERE \"idProgram\" = " + par.IdProgram + " AND \"idActor\"="+ par.IdActor +" AND \"idRole\" = "+ par.IdRole +";";
            NpgsqlDataAdapter daCount;
            DataSet dtCount = new DataSet();
            try
            {
                daCount = new NpgsqlDataAdapter(sSelCount, sConexion);
                daCount.Fill(dtCount);
                if (dtCount.Tables[0].Rows[0][0].ToString() == "0")
                    exist = false;
                else
                    exist = true;
            }
            catch (Exception)
            {
                exist = false;
            }
            if (!exist)
            {
                sSel = "INSERT INTO \"tbl_ProgramActorRole\" VALUES(" + par.IdProgram + "," + par.IdActor + "," + par.IdRole + ","+ par.Order +");";

                NpgsqlDataAdapter da;
                DataSet dt = new DataSet();

                try
                {
                    da = new NpgsqlDataAdapter(sSel, sConexion);
                    da.Fill(dt);
                }
                catch (Exception)
                {

                }
            }
        }

        public static DataSet actualShow(String channelNumber)
        {
            string sSel;
            bool exist;
            if (channelNumber != "")
            {
                sSel = "SELECT * ";
                sSel += "FROM \"tbl_Program\" p, \"tbl_Channel\" c, \"tbl_Schedule\" s ";
                sSel += "WHERE s.\"idProgram\" = p.\"idProgram\" AND s.\"idChannel\" = c.\"idChannel\" AND '" + DateTime.Now.ToString() + "' BETWEEN \"startDate\" AND \"endDate\" AND \"endDate\"<> '" + DateTime.Now.ToString() + "' AND c.\"channelNumber\"=" + channelNumber + " ";
            }
            else
            {
                sSel = "";
                return null;
            }


            NpgsqlDataAdapter da;
            DataSet dt = new DataSet();
            try
            {
                da = new NpgsqlDataAdapter(sSel, sConexion);
                da.Fill(dt);
                if (dt.Tables[0].Rows[0][0].ToString() == "0")
                    exist = false;
                else
                    exist = true;
            }
            catch (Exception)
            {
                return null;
            }

            return dt;
        }

        public void LimpiarHorario()
        {
            string sSel;

            sSel = "DELETE FROM \"tbl_Schedule\"";

            NpgsqlDataAdapter da;
            DataSet dt = new DataSet();

            try
            {
                da = new NpgsqlDataAdapter(sSel, sConexion);
                da.Fill(dt);
            }
            catch (Exception)
            {

            }
            
        }
    }
}
