using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml;
using System.Net.Json;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using FutbolInteractivoConnection;
using FutbolInteractivoData;
using System.Data;

namespace wcfFutbol
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FutbolService" in code, svc and config file together.
    public class FutbolService : IFutbolService
    {
        

        public string XMLData(string id)
        {
            string lol2="";
            bool lol = matchPlaying(out lol2);
            return "asdf" + id;
        }

        public string JSONIdTournament()
        {
            string id = null;

            XmlDocument doc = new XmlDocument();
            doc.Load("http://www.datafactory.ws/clientes/xml/index.php?ppaass=updl88updn&canal=deportes.futbol.eliminatorias.fixture");
            id = doc.SelectSingleNode("fixture/campeonato").Attributes["id"].Value;
            return id;
        }

        public string JSONEnVivo(string id)
        {
            DataFixture fixture = new DataFixture();
            string idMatch=null;
            XmlDocument doc = new XmlDocument();
            JsonStringValue played = null;
            if (!matchPlaying(out idMatch))
            {
                FutbolInteractivo conn = new FutbolInteractivo("2");
                

                fixture = conn.selectLastMatch(id);

                doc.Load("http://www.datafactory.ws/clientes/xml/index.php?ppaass=updl88updn&canal=deportes.futbol.eliminatorias.ficha." + fixture.IdFixture + "&tipo=3");
                played = new JsonStringValue("played", "Último partido");
            }
            else
            {
                doc.Load("http://www.datafactory.ws/clientes/xml/index.php?ppaass=updl88updn&canal=deportes.futbol.eliminatorias.ficha." + idMatch + "&tipo=3");
                played = new JsonStringValue("played", "En vivo");
            }
            XmlNode incidencias = doc.SelectSingleNode("Match/Incidences");


            string idLocal = doc.SelectSingleNode("Match/Teams/Team[@homeOrAway='Home']").Attributes["teamId"].Value;
            string nombreLocal = doc.SelectSingleNode("Match/Teams/Team[@homeOrAway='Home']").Attributes["name"].Value;

            string idVisita = doc.SelectSingleNode("Match/Teams/Team[@homeOrAway='Away']").Attributes["teamId"].Value;
            string nombreVisita = doc.SelectSingleNode("Match/Teams/Team[@homeOrAway='Away']").Attributes["name"].Value;

            XmlNode equipoL = null;
            XmlNode equipoV = null;

            JsonObjectCollection jsonFinal = new JsonObjectCollection();
            JsonObjectCollection localTeam = new JsonObjectCollection("Home");
            JsonObjectCollection visitTeam = new JsonObjectCollection("Visit");

            jsonFinal.Add(played);
            jsonFinal.Add(localTeam);
            jsonFinal.Add(visitTeam);

            JsonNumericValue idJsonH = new JsonNumericValue("id", Int32.Parse(idLocal));
            JsonNumericValue idJsonV = new JsonNumericValue("id", Int32.Parse(idVisita));

            JsonStringValue nameJsonH = new JsonStringValue("name", nombreLocal);
            JsonStringValue nameJsonV = new JsonStringValue("name", nombreVisita);

            JsonStringValue goalJsonH = new JsonStringValue("goal", "0");
            JsonStringValue goalJsonV = new JsonStringValue("goal", "0");

            JsonStringValue offJsonH = new JsonStringValue("offside", "0");
            JsonStringValue offJsonV = new JsonStringValue("offside", "0");

            JsonStringValue arrivalJsonH = new JsonStringValue("arrival", "0");
            JsonStringValue arrivalJsonV = new JsonStringValue("arrival", "0");

            JsonStringValue cornerJsonH = new JsonStringValue("corner", "0");
            JsonStringValue cornerJsonV = new JsonStringValue("corner", "0");

            JsonStringValue foulJsonH = new JsonStringValue("foul", "0");
            JsonStringValue foulJsonV = new JsonStringValue("foul", "0");

            JsonStringValue yellowJsonH = new JsonStringValue("yellow", "0");
            JsonStringValue yellowJsonV = new JsonStringValue("yellow", "0");

            JsonStringValue redJsonH = new JsonStringValue("red", "0");
            JsonStringValue redJsonV = new JsonStringValue("red", "0");

            JsonStringValue imgJsonH = new JsonStringValue("img", "http://190.215.44.18/FutbolService/Img/" + flag(fixture.IdHome.ToString()));
            JsonStringValue imgJsonV = new JsonStringValue("img", "http://190.215.44.18/FutbolService/Img/" + flag(fixture.IdVisit.ToString()));

            localTeam.Add(idJsonH);
            localTeam.Add(nameJsonH);
            localTeam.Add(goalJsonH);
            localTeam.Add(offJsonH);
            localTeam.Add(arrivalJsonH);
            localTeam.Add(cornerJsonH);
            localTeam.Add(foulJsonH);
            localTeam.Add(yellowJsonH);
            localTeam.Add(redJsonH);
            localTeam.Add(imgJsonH);

            visitTeam.Add(idJsonV);
            visitTeam.Add(nameJsonV);
            visitTeam.Add(goalJsonV);
            visitTeam.Add(offJsonV);
            visitTeam.Add(arrivalJsonV);
            visitTeam.Add(cornerJsonV);
            visitTeam.Add(foulJsonV);
            visitTeam.Add(yellowJsonV);
            visitTeam.Add(redJsonV);
            visitTeam.Add(imgJsonV);

            foreach (XmlNode incidencia in incidencias.ChildNodes)
            {
                if (incidencia.Attributes["playerId"] != null && incidencia.Attributes["playerId"].Value != "")
                {
                    try
                    {
                        equipoL = doc.SelectSingleNode("Match/Teams/Team[@homeOrAway='Home']/Players/Player[@playerId='" + incidencia.Attributes["playerId"].Value + "']").ParentNode.ParentNode;
                    }
                    catch (Exception)
                    {
                        equipoL = null;
                    }

                    try
                    {
                        equipoV = doc.SelectSingleNode("Match/Teams/Team[@homeOrAway='Away']/Players/Player[@playerId='" + incidencia.Attributes["playerId"].Value + "']").ParentNode.ParentNode;
                    }
                    catch (Exception)
                    {
                        equipoV = null;
                    }

                    if (equipoL != null)
                    {
                        switch (incidencia.Attributes["typeId"].Value)
                        {
                            case "33":
                            case "34":
                            case "35":
                                arrivalJsonH.Value = (Int32.Parse(arrivalJsonH.Value) + 1).ToString();
                                break;

                            case "36":
                                foulJsonH.Value = (Int32.Parse(foulJsonH.Value) + 1).ToString();
                                break;

                            case "10":
                                goalJsonV.Value = (Int32.Parse(goalJsonV.Value) + 1).ToString();
                                break;

                            case "9":
                            case "11":
                            case "12":
                            case "13":
                                goalJsonH.Value = (Int32.Parse(goalJsonH.Value) + 1).ToString();
                                break;

                            case "3":
                                yellowJsonH.Value = (Int32.Parse(yellowJsonH.Value) + 1).ToString();
                                break;

                            case "4":
                                redJsonH.Value = (Int32.Parse(redJsonH.Value) + 1).ToString();
                                break;

                            case "30":
                                break;

                            case "28":
                                cornerJsonH.Value = (Int32.Parse(cornerJsonH.Value) + 1).ToString();
                                break;

                            case "47":
                                offJsonH.Value = (Int32.Parse(offJsonH.Value) + 1).ToString();
                                break;

                            default:
                                break;
                        }
                    }
                    else if (equipoV != null)
                    {
                        switch (incidencia.Attributes["typeId"].Value)
                        {
                            case "33":
                            case "34":
                            case "35":
                                arrivalJsonV.Value = (Int32.Parse(arrivalJsonV.Value) + 1).ToString();
                                break;

                            case "36":
                                foulJsonV.Value = (Int32.Parse(foulJsonV.Value) + 1).ToString();
                                break;

                            case "10":
                                goalJsonH.Value = (Int32.Parse(goalJsonH.Value) + 1).ToString();
                                break;

                            case "9":
                            case "11":
                            case "12":
                            case "13":
                                goalJsonV.Value = (Int32.Parse(goalJsonV.Value) + 1).ToString();
                                break;

                            case "3":
                                yellowJsonV.Value = (Int32.Parse(yellowJsonV.Value) + 1).ToString();
                                break;

                            case "4":
                                redJsonV.Value = (Int32.Parse(redJsonV.Value) + 1).ToString();
                                break;

                            case "30":
                                break;

                            case "28":
                                cornerJsonV.Value = (Int32.Parse(cornerJsonV.Value) + 1).ToString();
                                break;

                            case "47":
                                offJsonV.Value = (Int32.Parse(offJsonV.Value) + 1).ToString();
                                break;

                            default:
                                break;
                        }
                    }
                }
            }


            String final = Convert.ToString(jsonFinal);
            final = final.Replace("\r", "");
            final = final.Replace("\n", "");
            final = final.Replace("\t", "");





            return final;
        }

        public string JSONFormacion(string id, string idTeam)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("http://www.datafactory.ws/clientes/xml/index.php?ppaass=updl88updn&canal=deportes.futbol.eliminatorias.ficha." + id + "&tipo=3");

            JsonObjectCollection jsonFinal = new JsonObjectCollection();

            JsonObjectCollection goalKeeper = new JsonObjectCollection("arquero");
            JsonObjectCollection defense = new JsonObjectCollection("defensas");
            JsonObjectCollection midfielder = new JsonObjectCollection("mediocampo");
            JsonObjectCollection forward = new JsonObjectCollection("delanteros");
            JsonObjectCollection subtitutes = new JsonObjectCollection("suplentes");
            JsonObjectCollection dt = new JsonObjectCollection("dt");
            int i = 0;
            DataSet _dsPlayer;
            FutbolInteractivo conn = new FutbolInteractivo("2");
            XmlNode player=null;
            foreach (XmlNode player2 in doc.SelectNodes("Match/Teams/Team[@teamId='" + idTeam + "']/Players/Player"))
            {
                JsonObjectCollection players = new JsonObjectCollection("player_" + i.ToString());
                if (player2.Attributes["substitute"].Value == "No" && player2.Attributes["position"].Value != "DT")
                {
                    foreach (XmlNode incidencia in doc.SelectNodes("Match/Incidences/Incidence[@typeId='7']"))
                    {
                        if (player2.Attributes["playerId"].Value == incidencia.Attributes["offId"].Value)
                        {
                            player = doc.SelectSingleNode("Match/Teams/Team[@teamId='" + player2.ParentNode.ParentNode.Attributes["teamId"].Value + "']/Players/Player[@playerId='" + incidencia.Attributes["inId"].Value + "']");
                            break;
                        }
                        else
                            player = player2;
                    }

                    switch (player.Attributes["positionId"].Value)
                    {
                        case "1":
                            {
                                goalKeeper.Add(players);
                                break;
                            }
                        case "2":
                            {
                                defense.Add(players);
                                break;
                            }
                        case "3":
                            {
                                midfielder.Add(players);
                                break;
                            }
                        case "4":
                            {
                                forward.Add(players);
                                break;
                            }
                    }
                }
                else if (player2.Attributes["substitute"].Value == "Yes")
                {
                    foreach (XmlNode incidencia in doc.SelectNodes("Match/Incidences/Incidence[@typeId='7']"))
                    {
                        if (player2.Attributes["playerId"].Value == incidencia.Attributes["inId"].Value)
                        {
                            player = doc.SelectSingleNode("Match/Teams/Team[@teamId='" + player2.ParentNode.ParentNode.Attributes["teamId"].Value + "']/Players/Player[@playerId='" + incidencia.Attributes["offId"].Value + "']");
                            break;
                        }
                        else
                            player = player2;
                    }

                    subtitutes.Add(players);
                }
                else if (player2.Attributes["position"].Value == "DT")
                {
                    dt.Add(players);
                    player = player2;
                }
                
                
                _dsPlayer = conn.selectPlayer(player.Attributes["playerId"].Value); 




                JsonNumericValue idPlayer = new JsonNumericValue("id", Int64.Parse(player.Attributes["playerId"].Value));
                JsonStringValue firstName = new JsonStringValue("nombre", player.Attributes["firstName"].Value);
                JsonStringValue lastName = new JsonStringValue("apellido", player.Attributes["lastName"].Value);
                JsonStringValue nickName = new JsonStringValue("apodo", player.Attributes["nickName"].Value);
                JsonNumericValue squadNumber = new JsonNumericValue("numero");
                if(player.Attributes["squadNumber"].Value!="")
                    squadNumber.Value = Int32.Parse(player.Attributes["squadNumber"].Value);
                JsonStringValue country = new JsonStringValue("pais", player.Attributes["country"].Value);
                JsonNumericValue age = new JsonNumericValue("edad", Int32.Parse(_dsPlayer.Tables[0].Rows[0]["playerAge"].ToString()));
                JsonNumericValue height = new JsonNumericValue("estatura", Int32.Parse(_dsPlayer.Tables[0].Rows[0]["playerHeight"].ToString()));
                JsonNumericValue weight = new JsonNumericValue("peso", Int32.Parse(_dsPlayer.Tables[0].Rows[0]["playerWeight"].ToString()));
                players.Add(idPlayer);
                players.Add(firstName);
                players.Add(lastName);
                players.Add(nickName);
                players.Add(squadNumber);
                players.Add(country);
                players.Add(age);
                players.Add(height);
                players.Add(weight);

                
                i++;
            }
            jsonFinal.Add(goalKeeper);
            jsonFinal.Add(defense);
            jsonFinal.Add(midfielder);
            jsonFinal.Add(forward);
            jsonFinal.Add(dt);
            jsonFinal.Add(subtitutes);

            String final = Convert.ToString(jsonFinal);
            final = final.Replace("\r", "");
            final = final.Replace("\n", "");
            final = final.Replace("\t", "");

            return final;
        }

        public string JSONPosiciones(string id)
        {
            FutbolInteractivo conn = new FutbolInteractivo("2");
            DataSet _dsPosition = conn.selectPositions(id);

            JsonObjectCollection jsonFinal = new JsonObjectCollection();
            int i = 0;
            foreach (DataRow dr in _dsPosition.Tables[0].Rows)
            {
                JsonObjectCollection team = new JsonObjectCollection("Team" + i.ToString());
                JsonNumericValue teamId = new JsonNumericValue("id", Int64.Parse(dr["idTeam"].ToString()));
                JsonStringValue teamName = new JsonStringValue("name", dr["teamName"].ToString());
                JsonNumericValue teamPts = new JsonNumericValue("pts", Int32.Parse(dr["teamPositionPoints"].ToString()));
                JsonNumericValue teamPj = new JsonNumericValue("pj", Int32.Parse(dr["teamPositionPlayed"].ToString()));
                JsonNumericValue teamPG = new JsonNumericValue("pg", Int32.Parse(dr["teamPositionWon"].ToString()));
                JsonNumericValue teamPE = new JsonNumericValue("pe", Int32.Parse(dr["teamPositionTied"].ToString()));
                JsonNumericValue teamPP = new JsonNumericValue("pp", Int32.Parse(dr["teamPositionLost"].ToString()));
                JsonNumericValue teamGD = new JsonNumericValue("gd", Int32.Parse(dr["teamPositionGoalDiff"].ToString()));
                JsonStringValue teamImg = new JsonStringValue("img", "http://190.215.44.18/FutbolService/Img/Fixture_" + flag(dr["idTeam"].ToString()));

                team.Add(teamId);
                team.Add(teamName);
                team.Add(teamPts);
                team.Add(teamPj);
                team.Add(teamPG);
                team.Add(teamPE);
                team.Add(teamPP);
                team.Add(teamGD);
                team.Add(teamImg);

                jsonFinal.Add(team);

                i++;
            }

            String final = Convert.ToString(jsonFinal);
            final = final.Replace("\r", "");
            final = final.Replace("\n", "");
            final = final.Replace("\t", "");

            return final;
        }

        public string JSONResultados(string idCampeonato)
        {
            
            FutbolInteractivo conn = new FutbolInteractivo("2");
            
            DataSet _dsResults = conn.selectResults(idCampeonato);

            JsonObjectCollection jsonFinal = new JsonObjectCollection();
            try
            {
                int i = 0;
                foreach (DataRow dr in _dsResults.Tables[0].Rows)
                {
                    JsonObjectCollection match = new JsonObjectCollection("match_" + i.ToString());
                    try
                    {
                        JsonNumericValue idPartido = new JsonNumericValue("id", Int64.Parse(dr["idFixture"].ToString()));
                        //JsonStringValue fecha = new JsonStringValue("fecha", DateTime.Parse(dr["datetime"].ToString()).ToShortDateString());
                        //JsonStringValue hora = new JsonStringValue("hora", DateTime.Parse(dr["datetime"].ToString()).ToShortTimeString());
                        //JsonStringValue lugarCiudad = new JsonStringValue("lugarCiudad",dr["city"].ToString());
                        //JsonStringValue nombreEstadio = new JsonStringValue("nombreEstadio", dr["stadium"].ToString());
                        JsonNumericValue idLocal = new JsonNumericValue("idLocal", Int64.Parse(dr["idHome"].ToString()));
                        JsonStringValue local = new JsonStringValue("local",dr["hometeam"].ToString());
                        JsonNumericValue idVisitante = new JsonNumericValue("idVisitante", Int64.Parse(dr["idvisit"].ToString()));
                        JsonStringValue visitante = new JsonStringValue("visitante", dr["visitteam"].ToString());
                        JsonStringValue golesLocal = new JsonStringValue("golesLocal", "");
                        JsonStringValue golesVisitante = new JsonStringValue("golesVisitante", "");
                        JsonStringValue estado = new JsonStringValue("estado", "");
                        
                        if (dr["fixturePlayed"].ToString() == "1")
                        {
                            golesLocal.Value = dr["homegoal"].ToString();
                            golesVisitante.Value = dr["visitgoal"].ToString();
                            estado.Value = dr["fixturePlayed"].ToString();
                        }
                        else
                        {
                            golesLocal.Value = "-";
                            golesVisitante.Value = "-";
                            estado.Value = dr["fixturePlayed"].ToString();
                        }

                        JsonStringValue imgLocal = new JsonStringValue("imgLocal", "http://190.215.44.18/FutbolService/Img/Fixture_" + flag(dr["idHome"].ToString()));                        

                        JsonStringValue imgVisita = new JsonStringValue("imgVisita", "http://190.215.44.18/FutbolService/Img/Fixture_" + flag(dr["idvisit"].ToString()));

                        match.Add(idPartido);
                        //match.Add(fecha);
                        //match.Add(hora);
                        //match.Add(lugarCiudad);
                        //match.Add(nombreEstadio);
                        match.Add(idLocal);
                        match.Add(local);
                        match.Add(golesLocal);
                        match.Add(idVisitante);
                        match.Add(visitante);
                        match.Add(golesVisitante);
                        match.Add(imgLocal);
                        match.Add(imgVisita);
                        match.Add(estado);
                        
                        i++;
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                    jsonFinal.Add(match);
                }

                String final = Convert.ToString(jsonFinal);
                final = final.Replace("\r", "");
                final = final.Replace("\n", "");
                final = final.Replace("\t", "");

                return final;  
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public string JSONResultados2(string idCampeonato, string idTeam)
        {

            FutbolInteractivo conn = new FutbolInteractivo("2");

            DataSet _dsResults = conn.selectResults(idTeam, idCampeonato);

            JsonObjectCollection jsonFinal = new JsonObjectCollection();
            try
            {
                int i = 0;
                foreach (DataRow dr in _dsResults.Tables[0].Rows)
                {
                    JsonObjectCollection match = new JsonObjectCollection("match_" + i.ToString());
                    try
                    {
                        JsonNumericValue idPartido = new JsonNumericValue("id", Int64.Parse(dr["idFixture"].ToString()));
                        //JsonStringValue fecha = new JsonStringValue("fecha", DateTime.Parse(dr["datetime"].ToString()).ToShortDateString());
                        //JsonStringValue hora = new JsonStringValue("hora", DateTime.Parse(dr["datetime"].ToString()).ToShortTimeString());
                        //JsonStringValue lugarCiudad = new JsonStringValue("lugarCiudad",dr["city"].ToString());
                        //JsonStringValue nombreEstadio = new JsonStringValue("nombreEstadio", dr["stadium"].ToString());
                        JsonNumericValue idLocal = new JsonNumericValue("idLocal", Int64.Parse(dr["idHome"].ToString()));
                        JsonStringValue local = new JsonStringValue("local", dr["hometeam"].ToString());
                        JsonNumericValue idVisitante = new JsonNumericValue("idVisitante", Int64.Parse(dr["idvisit"].ToString()));
                        JsonStringValue visitante = new JsonStringValue("visitante", dr["visitteam"].ToString());
                        JsonStringValue golesLocal = new JsonStringValue("golesLocal", "");
                        JsonStringValue golesVisitante = new JsonStringValue("golesVisitante", "");
                        JsonStringValue estado = new JsonStringValue("estado", "");

                        if (dr["fixturePlayed"].ToString() == "1")
                        {
                            golesLocal.Value = dr["homegoal"].ToString();
                            golesVisitante.Value = dr["visitgoal"].ToString();
                            estado.Value = dr["fixturePlayed"].ToString();
                        }
                        else
                        {
                            golesLocal.Value = "-";
                            golesVisitante.Value = "-";
                            estado.Value = dr["fixturePlayed"].ToString();
                        }

                        JsonStringValue imgLocal = new JsonStringValue("imgLocal", "http://190.215.44.18/FutbolService/Img/Fixture_" + flag(dr["idHome"].ToString()));

                        JsonStringValue imgVisita = new JsonStringValue("imgVisita", "http://190.215.44.18/FutbolService/Img/Fixture_" + flag(dr["idvisit"].ToString()));

                        match.Add(idPartido);
                        //match.Add(fecha);
                        //match.Add(hora);
                        //match.Add(lugarCiudad);
                        //match.Add(nombreEstadio);
                        match.Add(idLocal);
                        match.Add(local);
                        match.Add(golesLocal);
                        match.Add(idVisitante);
                        match.Add(visitante);
                        match.Add(golesVisitante);
                        match.Add(imgLocal);
                        match.Add(imgVisita);
                        match.Add(estado);

                        i++;
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                    jsonFinal.Add(match);
                }

                String final = Convert.ToString(jsonFinal);
                final = final.Replace("\r", "");
                final = final.Replace("\n", "");
                final = final.Replace("\t", "");

                return final;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public string JSONIncidencias(string idFixture)
        {

            FutbolInteractivo conn = new FutbolInteractivo("2");

            DataSet _dsIncidences = conn.selectIncidences(idFixture);

            JsonObjectCollection jsonFinal = new JsonObjectCollection();
            try
            {
                int i = 0;
                JsonObjectCollection stadium = new JsonObjectCollection("estadio");
                JsonStringValue stadiumName = new JsonStringValue("nombre", _dsIncidences.Tables[0].Rows[0]["fixtureStadium"].ToString());
                JsonStringValue stadiumImg = new JsonStringValue("img", "http://190.215.44.18/FutbolService/Img/icon-lugar.png");
                stadium.Add(stadiumName);
                stadium.Add(stadiumImg);

                JsonObjectCollection referee = new JsonObjectCollection("arbitro");
                string arbitro1 = _dsIncidences.Tables[0].Rows[0]["fixtureReferee"].ToString();
                string arbitro2 = arbitro1.Substring(0, arbitro1.IndexOf(",") + 1);
                arbitro1 = arbitro1.Replace(arbitro1.Substring(0, arbitro1.IndexOf(",") + 1), "");
                arbitro2 = arbitro2.Replace(",", "");
                JsonStringValue refereeName = new JsonStringValue("nombre", arbitro1.Trim() + " " + arbitro2.Trim());
                JsonStringValue refereeImg = new JsonStringValue("img", "http://190.215.44.18/FutbolService/Img/icon-arbitro.png");
                referee.Add(refereeName);
                referee.Add(refereeImg);

                JsonObjectCollection date = new JsonObjectCollection("fecha");
                JsonStringValue dateData = new JsonStringValue("data", _dsIncidences.Tables[0].Rows[0]["fixtureDateTime"].ToString());
                JsonStringValue dateImg = new JsonStringValue("img", "http://190.215.44.18/FutbolService/Img/icon-fecha.png");
                date.Add(dateData);
                date.Add(dateImg);

                JsonObjectCollection home = new JsonObjectCollection("local");
                JsonStringValue homeName = new JsonStringValue("nombre", _dsIncidences.Tables[0].Rows[0]["home"].ToString());
                JsonStringValue homeImg = new JsonStringValue("img", "http://190.215.44.18/FutbolService/Img/" + flag(_dsIncidences.Tables[0].Rows[0]["idHome"].ToString()));
                home.Add(homeName);
                home.Add(homeImg);

                JsonObjectCollection visit = new JsonObjectCollection("visita");
                JsonStringValue visitName = new JsonStringValue("nombre", _dsIncidences.Tables[0].Rows[0]["visit"].ToString());
                JsonStringValue visitImg = new JsonStringValue("img", "http://190.215.44.18/FutbolService/Img/" + flag(_dsIncidences.Tables[0].Rows[0]["idVisit"].ToString()));
                visit.Add(visitName);
                visit.Add(visitImg);

                jsonFinal.Add(stadium);
                jsonFinal.Add(referee);
                jsonFinal.Add(date);
                jsonFinal.Add(home);
                jsonFinal.Add(visit);

                JsonObjectCollection incidences = new JsonObjectCollection("incidences");

                foreach (DataRow dr in _dsIncidences.Tables[0].Rows)
                {
                    JsonObjectCollection incidence = new JsonObjectCollection("incidence_" + i.ToString());
                    try
                    {
                        JsonNumericValue idTipo = new JsonNumericValue("id", Int64.Parse(dr["idIncidenceType"].ToString()));
                        JsonNumericValue half = new JsonNumericValue("mitad", Int64.Parse(dr["fixtureDetailHalf"].ToString()));
                        JsonNumericValue minute = new JsonNumericValue("minuto", Int64.Parse(dr["fixtureDetailMinute"].ToString()));
                        JsonNumericValue second = new JsonNumericValue("segundo", Int64.Parse(dr["fixtureDetailSecond"].ToString()));
                        JsonStringValue team = new JsonStringValue("equipo");

                        if (dr["idTeam"].ToString() == dr["idHome"].ToString())
                            team.Value = "local";
                        else if(dr["idTeam"].ToString() == dr["idVisit"].ToString())
                            team.Value = "visita";

                        switch(dr["idIncidenceType"].ToString())
                        {
                            case "3":
                                {
                                    JsonStringValue player = new JsonStringValue("jugador", akaPlayer(dr["fixtureDetailPlayerName"].ToString()));
                                    JsonStringValue imgIncidence = new JsonStringValue("img");
                                    imgIncidence.Value = "http://190.215.44.18/FutbolService/Img/icon-amarilla.png";
                                    incidence.Add(imgIncidence);
                                    incidence.Add(player);
                                    break;
                                }
                            case "4":
                            case "5":
                                {
                                    JsonStringValue player = new JsonStringValue("jugador", akaPlayer(dr["fixtureDetailPlayerName"].ToString()));
                                    JsonStringValue imgIncidence = new JsonStringValue("img");
                                    imgIncidence.Value = "http://190.215.44.18/FutbolService/Img/icon-roja.png";
                                    incidence.Add(imgIncidence);
                                    incidence.Add(player);
                                    break;
                                }
                            case "7":
                                {
                                    JsonStringValue imgIn = new JsonStringValue("imgIn", "http://190.215.44.18/FutbolService/Img/in.png");
                                    JsonStringValue imgOut = new JsonStringValue("imgOut", "http://190.215.44.18/FutbolService/Img/out.png");
                                    JsonStringValue playerIn = new JsonStringValue("entra", akaPlayer(dr["fixtureDetailPlayerName2"].ToString()));
                                    JsonStringValue playerOut = new JsonStringValue("sale", akaPlayer(dr["fixtureDetailPlayerName"].ToString()));
                                    incidence.Add(imgIn);
                                    incidence.Add(playerIn);
                                    incidence.Add(imgOut);
                                    incidence.Add(playerOut);
                                    break;
                                }
                            case "9":
                            case "10":
                            case "11":
                            case "12":
                            case "13":
                                {
                                    JsonStringValue player = new JsonStringValue("jugador", akaPlayer(dr["fixtureDetailPlayerName"].ToString()));
                                    JsonStringValue imgIncidence = new JsonStringValue("img");
                                    imgIncidence.Value = "http://190.215.44.18/FutbolService/Img/icon-balon.png";
                                    incidence.Add(imgIncidence);
                                    incidence.Add(player);
                                    break;
                                }
                        }

                        incidence.Add(idTipo);
                        incidence.Add(team);
                        incidence.Add(half);
                        incidence.Add(minute);
                        incidence.Add(second);

                        i++;
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                    incidences.Add(incidence);
                }
                jsonFinal.Add(incidences);
                String final = Convert.ToString(jsonFinal);
                final = final.Replace("\r", "");
                final = final.Replace("\n", "");
                final = final.Replace("\t", "");

                return final;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public string JSONGoleadores(string idCampeonato)
        {

            FutbolInteractivo conn = new FutbolInteractivo("2");

            DataSet _dsStrikers = conn.selectStriker(idCampeonato);

            JsonObjectCollection jsonFinal = new JsonObjectCollection();
            try
            {
                int i = 0;
                foreach (DataRow dr in _dsStrikers.Tables[0].Rows)
                {
                    JsonObjectCollection striker = new JsonObjectCollection("striker_" + i.ToString());

                    JsonStringValue name = new JsonStringValue("nombre", dr["strikerFullName"].ToString());
                    JsonStringValue team = new JsonStringValue("equipo", "Selección de " + dr["teamName"].ToString());
                    JsonStringValue img = new JsonStringValue("img", "http://190.215.44.18/FutbolService/Img/" + flag(dr["idTeam"].ToString()).Replace("Bandera_",""));
                    JsonStringValue goal = new JsonStringValue("goles");
                    if (Int32.Parse(dr["strikerGoal"].ToString()) > 1)
                        goal.Value = dr["strikerGoal"].ToString() + " Goles";
                    else
                        goal.Value = dr["strikerGoal"].ToString() + " Gol";

                    striker.Add(name);
                    striker.Add(team);
                    striker.Add(img);
                    striker.Add(goal);

                    jsonFinal.Add(striker);
                    i++;
                }


                
                String final = Convert.ToString(jsonFinal);
                final = final.Replace("\r", "");
                final = final.Replace("\n", "");
                final = final.Replace("\t", "");

                return final;
            }
            catch (Exception)
            {
                return null;
            }

        }
        
        private string flag(string id)
        {
            switch (id)
            {
                case "21": 
                    {
                        return "Bandera_Argentina.png";
                    }
                case "159":
                    {
                        return "Bandera_Chile.png";
                    }
                case "166":
                    {
                        return "Bandera_Bolivia.png";
                    }
                case "168":
                    {
                        return "Bandera_Colombia.png";
                    }
                case "169":
                    {
                        return "Bandera_Ecuador.png";
                    }
                case "170":
                    {
                        return "Bandera_Paraguay.png";
                    }
                case "171":
                    {
                        return "Bandera_Peru.png";
                    }
                case "172":
                    {
                        return "Bandera_Uruguay.png";
                    }
                case "173":
                    {
                        return "Bandera_Venezuela.png";
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        private bool matchPlaying(out string id)
        {
            id = null;

            XmlDocument doc = new XmlDocument();
            doc.Load("http://www.datafactory.ws/clientes/xml/index.php?ppaass=updl88updn&canal=deportes.futbol.eliminatorias.fixture");
            XmlNodeList partidos = doc.SelectNodes("fixture/fecha/partido[estado[@id!='2']]");
            if (partidos[0].ChildNodes[0].Attributes["id"].Value == "1" || partidos[0].ChildNodes[0].Attributes["id"].Value == "6")
            {
                id = partidos[0].Attributes["id"].Value;
                return true;
            }
            else
                return false;
        }

        private String akaPlayer(String playerName)
        {
            try
            {
                if (playerName.Contains("."))
                    return playerName;
                else if (playerName.Contains(" "))
                {
                    string s = playerName.Substring(0, playerName.IndexOf(" ") + 1);
                    string s2 = playerName.Substring(playerName.LastIndexOf(" "), playerName.Length - playerName.LastIndexOf(" "));
                    playerName = s.Substring(0, 1) + ". " + s2.Trim();
                }
            }
            catch (Exception ex)
            {
                string asd = ex.Message;
            }
            return playerName;
        }
    }
}
