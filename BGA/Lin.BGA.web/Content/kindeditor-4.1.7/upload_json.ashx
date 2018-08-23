<%@ webhandler Language="C#" class="Upload" %>

/**
 * KindEditor ASP.NET
 *
 * 本ASP.NET程序是演示程序，建议不要直接在实际项目中使用。
 * 如果您确定直接使用本程序，使用之前请仔细确认相关安全设置。
 *
 */

using System;
using System.Collections;
using System.Web;
using System.IO;
using System.Globalization;
using Newtonsoft.Json;
using Tool;

public class Upload : IHttpHandler
{
    //文件保存目录路径
    private String savePath = ImgHelper.TempDir;
    //文件保存目录URL
    private String saveUrl = ImgHelper.TempDir;
    //定义允许上传的文件扩展名
    private String fileTypes = "gif,jpg,jpeg,png,bmp";
    //最大文件大小
    private int maxSize = 1000000;

    private HttpContext context;
    public void DeleteFolder(string dir)
    {
        if (Directory.Exists(dir)) //如果存在这个文件夹删除之   
        {
            foreach (string d in Directory.GetFileSystemEntries(dir))
            {
                if (File.Exists(d))
                    File.Delete(d); //直接删除其中的文件                          
                else
                    DeleteFolder(d); //递归删除子文件夹   
            }
            Directory.Delete(dir, true); //删除已空文件夹                   
        }
    }
    public void ProcessRequest(HttpContext context)
    {
        string MidPath = DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
        this.context = context;

        if (context.Request["action"]=="remove")
        {
            string FilePath = context.Request["FilePath"];
            if (FilePath==null)
            {
                FilePath = string.Empty;
            }
            DeleteFolder(context.Server.MapPath("~/" + FilePath));
        }

        HttpPostedFile imgFile = context.Request.Files["imgFile"];
        if (imgFile == null)
        {
            showError("请选择文件。");
        }

        String dirPath = context.Server.MapPath(savePath+MidPath);
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
            //showError("上传目录不存在。");
        }

        String fileName = imgFile.FileName;
        String fileExt = Path.GetExtension(fileName).ToLower();
        ArrayList fileTypeList = ArrayList.Adapter(fileTypes.Split(','));

        if (imgFile.InputStream == null || imgFile.InputStream.Length > maxSize)
        {
            showError("上传文件大小超过限制。");
        }

        if (!imgFile.ContentType.Contains("image"))////////////////////
        {
            showError("上传文件类型不允许。");
        }
        if (String.IsNullOrEmpty(fileExt) || Array.IndexOf(fileTypes.Split(','), fileExt.Substring(1).ToLower()) == -1)
        {
            showError("上传文件扩展名是不允许的扩展名。");
        }

        String newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;
        String filePath = dirPath + newFileName;

        imgFile.SaveAs(filePath);

        String fileUrl = saveUrl +MidPath+ newFileName;

        Hashtable hash = new Hashtable();
        hash["error"] = 0;
        hash["url"] = fileUrl;
        context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
        context.Response.Write(JsonConvert.SerializeObject(hash));
        context.Response.End();
    }

    private void showError(string message)
    {
        Hashtable hash = new Hashtable();
        hash["error"] = 1;
        hash["message"] = message;
        context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
        context.Response.Write(JsonConvert.SerializeObject(hash));
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return true;
        }
    }
}
