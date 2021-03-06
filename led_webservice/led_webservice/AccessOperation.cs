﻿using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace led_webservice
{
    public class AccessOperation
    {
        public static string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = C:\inetpub\wwwroot\upload_files\LED_Manager.mdb";
        #region 私有构造函数和方法
        private AccessOperation() { }
        private static void PrepareCommand(OleDbCommand cmd, OleDbConnection conn, string cmdText, OleDbParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = CommandType.Text;
            if (cmdParms != null)
            {
                foreach (OleDbParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
        #endregion

        #region 简单SQL语句
        public static bool Exists(string sql)
        {
            object obj = ExecuteScalar(sql);
            string cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                cmdresult = "0";
            else
                cmdresult = Convert.ToString(obj);
            return cmdresult != "0";
        }
        public static bool Exists(string sql, OleDbParameter[] parameters)
        {
            object obj = ExecuteScalar(sql, parameters);
            string cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                cmdresult = "0";
            else
                cmdresult = Convert.ToString(obj);
            return cmdresult != "0";
        }
        public static object ExecuteScalar(string SQLString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                            return null;
                        else
                            return obj;
                    }
                    catch (Exception e)
                    {
                        connection.Close();
                 
                    }
                }
                return null;
            }
        }
        public static object ExecuteScalar(string SQLString, OleDbParameter[] parameters)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        PrepareCommand(cmd, connection, SQLString, parameters);
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                            return null;
                        else
                            return obj;
                    }
                    catch (Exception e)
                    {
                        connection.Close();
                        Console.WriteLine(e);
                    }
                }
            }
            return null;
        }
        public static int ExecuteNonQuery(string sql)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(sql, connection))
                {
                    try
                    {
                        connection.Open();
                        int n = cmd.ExecuteNonQuery();
                        return n;
                    }
                    catch (Exception e)
                    {
                        connection.Close();
                        Console.WriteLine(e);
                    }
                }
            }
            return 0;
        }
        public static int ExecuteNonQuery(string SQLString, params OleDbParameter[] cmdParms)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, SQLString, cmdParms);
                        object n = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return Convert.ToInt32(n);//
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    return 0;
                }
            }
        }
        public static int ExecuteSqlTran(ArrayList SQLStringList)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                OleDbTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                int count = 0;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            count += cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
                catch (Exception e)
                {
                    tx.Rollback();
                    Console.WriteLine(e);
                }
                return count;
            }
        }
        public static DataSet Query(string SQLString, OleDbParameter[] parameters, string TabName)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand();
                PrepareCommand(cmd, connection, SQLString, parameters);
                using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, TabName);
                        cmd.Parameters.Clear();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    return ds;
                }
            }
        }
        public static DataSet Query(string SQLString, string TabName)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    OleDbDataAdapter command = new OleDbDataAdapter(SQLString, connection);
                    command.Fill(ds, TabName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                return ds;
            }
        }
        public static OleDbDataReader ExecuteReader(string SQLString, params OleDbParameter[] cmdParms)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand(SQLString, connection);
            try
            {
                PrepareCommand(cmd, connection, SQLString, cmdParms);
                OleDbDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        public static OleDbDataReader ExecuteReader(string SQLString)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand(SQLString, connection);
            try
            {
                connection.Open();
                OleDbDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return myReader;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
           }
        }
    #endregion
}