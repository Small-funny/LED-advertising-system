using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Web.Services;

namespace led_webservice
{
    /// <summary>
    /// file_upload 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class file_upload : System.Web.Services.WebService
    {

        [WebMethod(Description = "测试")]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(Description = "在服务器上创建文件")]
        public bool CreateFile(string fileName)
        {
            bool isCreate = true;
            try
            {
                fileName = Path.Combine(Server.MapPath(""), Path.GetFileName(fileName));
                FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                fs.Close();
            }
            catch
            {
                isCreate = false;
            }
            return isCreate;
        }

        [WebMethod(Description = "上传文件")]
        public bool Append(string fileName, byte[] buffer , bool flag)
        {
            bool isAppend = true;
            try
            {
                //fileName = Path.Combine(@"C:\NMGIS_Video" + Path.GetFileName(fileName));  
                string file_dir = "";
                
                fileName = Path.Combine(Server.MapPath(file_dir), Path.GetFileName(fileName));
                
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                fs.Seek(0, SeekOrigin.End);
                fs.Write(buffer, 0, buffer.Length);
                fs.Close();
            }
            catch
            {
                isAppend = false;
            }
            return isAppend;
        }

        [WebMethod(Description = "验证文件是否存在")]
        public bool Verify(string fileName, string md5 , bool flag)
        {
            bool isVerify = true;
            try
            {
                string file_dir = "";
                
                fileName = Path.Combine(Server.MapPath(file_dir), Path.GetFileName(fileName));

                // fileName = Server.MapPath（"D:\MesWebCR\picture")  + Path.GetFileName(fileName);
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                MD5CryptoServiceProvider p = new MD5CryptoServiceProvider();
                byte[] md5buffer = p.ComputeHash(fs);
                fs.Close();
                string md5Str = "";
                for (int i = 0; i < md5buffer.Length; i++)
                {
                    md5Str += md5buffer[i].ToString("x2");
                }
                if (md5 != md5Str)
                    isVerify = false;
            }
            catch
            {
                isVerify = false;
            }
            return isVerify;
        }

        [WebMethod(Description = "获取文件列表")]
        public  string[] files_name()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\inetpub\wwwroot\upload_files");
            FileInfo[] fileInfo = dir.GetFiles();
            List<string> fileNames = new List<string>();
            foreach (FileInfo item in fileInfo)
            {
                fileNames.Add(item.Name);
            }
            return fileNames.ToArray();
        }

        [WebMethod(Description = "获取截图列表")]
        public string[] screenfiles_name()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\inetpub\wwwroot\upload_files\getscreen");
            FileInfo[] fileInfo = dir.GetFiles();
            List<string> fileNames = new List<string>();
            foreach (FileInfo item in fileInfo)
            {
                fileNames.Add(item.Name);
            }
            return fileNames.ToArray();
        }

        [WebMethod(Description = "删除文件")]
        public string delete_file(string file_name)
        {
            try
            {
                string file_dir = @"C:\inetpub\wwwroot\upload_files";
                file_name = Path.Combine(file_dir, Path.GetFileName(file_name));

                if (File.Exists(file_name))
                {
                    File.Delete(file_name);
                    return "删除成功！";
                }
                else 
                    return "删除失败(1)！";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return "删除失败(2)！";
            }
        }

        [WebMethod(Description = "删除截图")]
        public string delete_screenfile(string file_name)
        {
            try
            {
                string file_dir = @"C:\inetpub\wwwroot\upload_files\getscreen";
                file_name = Path.Combine(file_dir, Path.GetFileName(file_name));

                if (File.Exists(file_name))
                {
                    File.Delete(file_name);
                    return "删除成功！";
                }
                else
                    return "删除失败(1)！";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return "删除失败(2)！";
            }
        }

        [WebMethod(Description = "下载服务器上的文件")]
        public byte[] DownloadFile(string file_name)
        {
            FileStream fs = null;
            string file_dir = @"C:\inetpub\wwwroot\upload_files";
            file_dir = Path.Combine(file_dir, Path.GetFileName(file_name));

            if (File.Exists(file_dir))
            {
                try
                {
                    ///打开现有文件以进行读取。
                    fs = File.OpenRead(file_dir);
                    int b1;
                    System.IO.MemoryStream tempStream = new System.IO.MemoryStream();
                    while ((b1 = fs.ReadByte()) != -1)
                    {
                        tempStream.WriteByte(((byte)b1));
                    }
                    return tempStream.ToArray();
                }
                catch (Exception ex)
                {
                    return new byte[0];
                }
                finally
                {
                    fs.Close();
                }
            }
            else
            {
                return new byte[0];
            }
        }

        [WebMethod(Description = "下载服务器上的截图")]
        public byte[] DownloadScreen(string file_name)
        {
            FileStream fs = null;
            string file_dir = @"C:\inetpub\wwwroot\upload_files\getscreen";
            file_dir = Path.Combine(file_dir, Path.GetFileName(file_name));

            if (File.Exists(file_dir))
            {
                try
                {
                    ///打开现有文件以进行读取。
                    fs = File.OpenRead(file_dir);
                    int b1;
                    System.IO.MemoryStream tempStream = new System.IO.MemoryStream();
                    while ((b1 = fs.ReadByte()) != -1)
                    {
                        tempStream.WriteByte(((byte)b1));
                    }
                    return tempStream.ToArray();
                }
                catch (Exception ex)
                {
                    return new byte[0];
                }
                finally
                {
                    fs.Close();
                }
            }
            else
            {
                return new byte[0];
            }
        }

        [WebMethod(Description = "发送播放表单")]
        public string submit_list(string listname)
        {
            try
            {
                string str = File.ReadAllText(@"C:\inetpub\wwwroot\upload_files\" + listname);
                return str;
            }
            catch (Exception e)
            {
                return "服务器出错！";
            }
        }

        [WebMethod(Description = "获取getscreen文件夹下所有文件大小")]
        public string[] files_size()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\inetpub\wwwroot\upload_files\getscreen");
            FileInfo[] fileInfo = dir.GetFiles();
            List<string> filesize = new List<string>();
            foreach (FileInfo item in fileInfo)
            {
                filesize.Add(item.Length.ToString());
            }
            return filesize.ToArray();
        }


        [WebMethod(Description = "查询多条记录，返回Dataset类型数据")]
        public DataSet Access_findAll(string sql , string table)
        {
            DataSet dataset = AccessOperation.Query(sql , table);
            return dataset;
        }

        [WebMethod(Description ="查询单条记录，返回object类型数据")]
        public object Access_find(string sql)
        {
            object res = AccessOperation.ExecuteScalar(sql);
            return res;
        }

        [WebMethod(Description = "更新记录，返回字符串形式更新情况")]
        public string Access_update(string sql)
        {
            try
            {
                AccessOperation.ExecuteNonQuery(sql);
                return "修改成功！";
            }
            catch(Exception e)
            {
                return "修改失败！";
            }
        }

        [WebMethod(Description ="插入记录，不返回插入结果")]
        public void Access_insert(string sql)
        {
            try
            {
                AccessOperation.ExecuteNonQuery(sql);
            }
            catch(Exception e)
            {

            }
        }

        [WebMethod(Description ="删除记录，字符串形式返回删除结果")]
        public string Access_delete(string sql)
        {
            try
            {
                AccessOperation.ExecuteNonQuery(sql);
                return "删除成功！";
            }
            catch (Exception e)
            {
                return "删除失败！";
            }
        }

        [WebMethod(Description ="检查是否有目标记录，返回bool型结果")]
        public bool Access_Exist(string sql)
        {
            bool res = AccessOperation.Exists(sql);
            return res;
        }

        [WebMethod(Description = "返回当前链接id")]
        public string channels_id()
        {
            try
            {
                string str = File.ReadAllText(@"C:\inetpub\wwwroot\upload_files\idlist.txt");
                return str;
            }
            catch (Exception e)
            {
                return "服务器出错！";
            }
        }
    }
}