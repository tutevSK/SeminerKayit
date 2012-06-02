using System;
using System.Web;
using System.Configuration;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using tutevDataLayer.Helper;

namespace tutevDataLayer.Controller
{

    public class BaseDbDao
    {
        public BaseDbDao()
        { }
                                //
        //public int InsertLog(GenDbLog nesne, DbTransaction dbTransaction, Database db)
        //{
        //    string sqlText = "INSERT INTO GEN_DB_LOG (TCKIMLIKNO,KULLANICI_IP,TABLO,KAYIT_ID,KAYIT,YAPILAN_ISLEM,TARIH)VALUES(@kullaniciAdi,@kullaniciIp,@tablo,@kayitId,@kayit,@yapilanIslem,@tarih)SELECT @@IDENTITY";
        //    DbCommand dbComm = db.GetSqlStringCommand(sqlText);
        //    db.AddInParameter(dbComm, "@kullaniciAdi", DbType.String, nesne.Tckimlikno == null ? (object)DBNull.Value : nesne.Tckimlikno);
        //    db.AddInParameter(dbComm, "@kullaniciIp", DbType.String, nesne.KullaniciIp == null ? (object)DBNull.Value : nesne.KullaniciIp);
        //    db.AddInParameter(dbComm, "@tablo", DbType.String, nesne.Tablo == null ? (object)DBNull.Value : nesne.Tablo);
        //    db.AddInParameter(dbComm, "@kayitId", DbType.Int32, nesne.KayitId == null ? (object)DBNull.Value : nesne.KayitId);
        //    db.AddInParameter(dbComm, "@kayit", DbType.String, nesne.Kayit == null ? (object)DBNull.Value : nesne.Kayit);
        //    db.AddInParameter(dbComm, "@yapilanIslem", DbType.String, nesne.YapilanIslem == null ? (object)DBNull.Value : nesne.YapilanIslem);
        //    db.AddInParameter(dbComm, "@tarih", DbType.DateTime, nesne.Tarih == null ? (object)DBNull.Value : nesne.Tarih);
        //    if (dbTransaction == null) return int.Parse(db.ExecuteScalar(dbComm).ToString());
        //    else return int.Parse(db.ExecuteScalar(dbComm, dbTransaction).ToString());
        //    return 1;
        //}

        protected int Update(BaseTable nesne, DbCommand dbComm, DbTransaction dbTransaction, Database db)
        {
            //YetkiKullanici ui = (YetkiKullanici)HttpContext.Current.Session["YetkiKullanici"];
            //if (ui == null)
            //{
            //    ui = new YetkiKullanici();
            //    ui.Tckimlikno = "Everyone";
            //    ui.Ip = HttpContext.Current.Request.UserHostAddress;
            //}

            int sonuc = -1;
            //if (dbTransaction == null) sonuc = int.Parse(db.ExecuteNonQuery(dbComm).ToString());
            //else sonuc = int.Parse(db.ExecuteNonQuery(dbComm, dbTransaction).ToString());
            //if (ConfigurationSettings.AppSettings.Get("DBLOG_AKTIF") != null &&
            //    ConfigurationSettings.AppSettings.Get("DBLOG_AKTIF") == "E")
            //{
            //    try
            //    {
            //        GenDbLog log = new GenDbLog();
            //        log.Tckimlikno = ui.Tckimlikno;
            //        log.KullaniciIp = ui.Ip;
            //        log.Tablo = nesne.GetName();
            //        log.KayitId = (int)nesne.PrimaryKey;
            //        log.Kayit = nesne.ToString();
            //        log.Tarih = DateTime.Now;
            //        log.YapilanIslem = "U";
            //        InsertLog(log, dbTransaction, db);
            //    }
            //    catch (Exception ex) { }
            //}
            return sonuc;
        }
        protected int Insert(BaseTable nesne, DbCommand dbComm, DbTransaction dbTransaction, Database db)
        {
            //YetkiKullanici ui = (YetkiKullanici)HttpContext.Current.Session["YetkiKullanici"];
            //if (ui == null)
            //{
            //    ui = new YetkiKullanici();
            //    ui.Tckimlikno = "Everyone";
            //    ui.Ip = HttpContext.Current.Request.UserHostAddress;
            //}

            int sonuc = 0;
            string geriDeger = "";
            if (dbTransaction == null) geriDeger = db.ExecuteScalar(dbComm).ToString();
            else geriDeger = db.ExecuteScalar(dbComm, dbTransaction).ToString();
            //if (ConfigurationSettings.AppSettings.Get("DBLOG_AKTIF") != null &&
            //    ConfigurationSettings.AppSettings.Get("DBLOG_AKTIF") == "E")
            //{
            //    try
            //    {
            //        int.TryParse(geriDeger, out sonuc);
            //        GenDbLog log = new GenDbLog();
            //        log.Tckimlikno = ui.Tckimlikno;
            //        log.KullaniciIp = ui.Ip;
            //        log.Tablo = nesne.GetName();
            //        log.KayitId = sonuc;
            //        log.Kayit = nesne.ToString();
            //        log.Tarih = DateTime.Now;
            //        log.YapilanIslem = "I";
            //        InsertLog(log, dbTransaction, db);
            //    }
            //    catch (Exception ex) { }
            //}
            bool snc = int.TryParse(geriDeger, out sonuc);
            return sonuc;
        }
        protected int Delete(BaseTable nesne, DbCommand dbComm, DbTransaction dbTransaction, Database db)
        {
            //YetkiKullanici ui = (YetkiKullanici)HttpContext.Current.Session["YetkiKullanici"];
            //if (ui == null)
            //{
            //    ui = new YetkiKullanici();
            //    ui.Tckimlikno = "Everyone";
            //    ui.Ip = HttpContext.Current.Request.UserHostAddress;
            //}

            int sonuc = -1;
            //if (dbTransaction == null) sonuc = int.Parse(db.ExecuteNonQuery(dbComm).ToString());
            //else sonuc = int.Parse(db.ExecuteNonQuery(dbComm, dbTransaction).ToString());
            //if (ConfigurationSettings.AppSettings.Get("DBLOG_AKTIF") != null &&
            //    ConfigurationSettings.AppSettings.Get("DBLOG_AKTIF") == "E" && sonuc > -1)
            //{
            //    try
            //    {
            //        GenDbLog log = new GenDbLog();
            //        log.Tckimlikno = ui.Tckimlikno;
            //        log.KullaniciIp = ui.Ip;
            //        log.Tablo = nesne.GetName();
            //        log.KayitId = (int)nesne.PrimaryKey;
            //        log.Kayit = "SİLİNDİ";
            //        log.Tarih = DateTime.Now;
            //        log.YapilanIslem = "D";
            //        InsertLog(log, dbTransaction, db);
            //    }
            //    catch (Exception ex) { }
            //}
            return sonuc;
        }
    }
}