using System; 
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using tutevDataLayer.Controller;

namespace tutevDataLayer.Core {

	public class KatilimciOrganizasyonAratabloDao:BaseDbDao {

		private KatilimciOrganizasyonAratablo nesne;
		private string sqlText;
		private string orderBy;
		private DbCommand dbComm = null;

		public KatilimciOrganizasyonAratabloDao() {}

		public int Insert(KatilimciOrganizasyonAratablo nesne,DbTransaction dbTransaction,Database db){
 			sqlText="INSERT INTO KATILIMCI_ORGANIZASYON_ARATABLO (ORGANIZASYON_ID,KATILIMCI_ID,KAYIT_NO)VALUES(@organizasyonId,@katilimciId,@kayitNo)SELECT @@IDENTITY";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@organizasyonId", DbType.Int32, nesne.OrganizasyonId==null?(object)DBNull.Value:nesne.OrganizasyonId);
			db.AddInParameter(dbComm, "@katilimciId", DbType.Int32, nesne.KatilimciId==null?(object)DBNull.Value:nesne.KatilimciId);
			db.AddInParameter(dbComm, "@kayitNo", DbType.Int32, nesne.KayitNo==null?(object)DBNull.Value:nesne.KayitNo);
			return base.Insert(nesne, dbComm, dbTransaction, db);
		}

		public int Update(KatilimciOrganizasyonAratablo nesne,DbTransaction dbTransaction,Database db){
 			sqlText=" UPDATE KATILIMCI_ORGANIZASYON_ARATABLO set ORGANIZASYON_ID = @organizasyonId , KAYIT_NO = @kayitNo WHERE KATILIMCI_ID = @katilimciId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@organizasyonId", DbType.Int32, nesne.OrganizasyonId==null?(object)DBNull.Value:nesne.OrganizasyonId);
			db.AddInParameter(dbComm, "@katilimciId", DbType.Int32, nesne.KatilimciId==null?(object)DBNull.Value:nesne.KatilimciId);
			db.AddInParameter(dbComm, "@kayitNo", DbType.Int32, nesne.KayitNo==null?(object)DBNull.Value:nesne.KayitNo);
			return base.Update(nesne, dbComm, dbTransaction, db);
		}

		public int Delete(int katilimciId,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE KATILIMCI_ORGANIZASYON_ARATABLO where KATILIMCI_ID=@katilimciId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@katilimciId", DbType.Int32, katilimciId);
			KatilimciOrganizasyonAratablo nesne = new KatilimciOrganizasyonAratablo();
			nesne.KatilimciId = katilimciId;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}

		public KatilimciOrganizasyonAratablo GetById(int katilimciId,Database db){
 			nesne = new KatilimciOrganizasyonAratablo();
			sqlText="Select ORGANIZASYON_ID,KATILIMCI_ID,KAYIT_NO from KATILIMCI_ORGANIZASYON_ARATABLO where KATILIMCI_ID=@katilimciId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@katilimciId", DbType.Int32, katilimciId);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				if(reader.Read()){
					nesne = FillKatilimciOrganizasyonAratablo(reader);
				}else nesne=null;
			}
			return nesne;
		}

		public DataSet GetAll(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ORGANIZASYON_ID,KATILIMCI_ID,KAYIT_NO from KATILIMCI_ORGANIZASYON_ARATABLO "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetAllReader(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ORGANIZASYON_ID,KATILIMCI_ID,KAYIT_NO from KATILIMCI_ORGANIZASYON_ARATABLO "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteReader(dbComm);
		}

		public List<KatilimciOrganizasyonAratablo> GetAllList(string OrderBy,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ORGANIZASYON_ID,KATILIMCI_ID,KAYIT_NO from KATILIMCI_ORGANIZASYON_ARATABLO "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<KatilimciOrganizasyonAratablo> katilimciorganizasyonaratabloList = new List<KatilimciOrganizasyonAratablo>();
				while(reader.Read()){
					KatilimciOrganizasyonAratablo katilimciorganizasyonaratablo = FillKatilimciOrganizasyonAratablo(reader);
					katilimciorganizasyonaratabloList.Add( katilimciorganizasyonaratablo);
				}
				return katilimciorganizasyonaratabloList;
			}
		}

		public DataSet GetByAll(string OrderBy,Int32 OrganizasyonId,Int32 KayitNo,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText=@"Select ORGANIZASYON_ID,KATILIMCI_ID,KAYIT_NO from KATILIMCI_ORGANIZASYON_ARATABLO Where 1=1 
 						 and (ORGANIZASYON_ID = @organizasyonId or @organizasyonId =-1)
						 and (KAYIT_NO = @kayitNo or @kayitNo =-1)
						"+orderBy;
			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@organizasyonId", DbType.Int32, OrganizasyonId);
			db.AddInParameter(dbComm, "@kayitNo", DbType.Int32, KayitNo);
			return db.ExecuteDataSet(dbComm);
		}


		public KatilimciOrganizasyonAratablo FillKatilimciOrganizasyonAratablo(IDataReader reader){
 			nesne = new KatilimciOrganizasyonAratablo();
			nesne.OrganizasyonId=(Int32)reader["ORGANIZASYON_ID"];
			nesne.KatilimciId=(Int32)reader["KATILIMCI_ID"];
			nesne.KayitNo=(Int32)reader["KAYIT_NO"];
			return nesne;
		}

		public DataSet GetByOrganizasyonId(string OrderBy,Int32 organizasyonId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ORGANIZASYON_ID,KATILIMCI_ID,KAYIT_NO from KATILIMCI_ORGANIZASYON_ARATABLO Where ORGANIZASYON_ID=@organizasyonId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@organizasyonId", DbType.Int32, organizasyonId);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetByOrganizasyonIdReader(string OrderBy,Int32 organizasyonId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ORGANIZASYON_ID,KATILIMCI_ID,KAYIT_NO from KATILIMCI_ORGANIZASYON_ARATABLO Where ORGANIZASYON_ID=@organizasyonId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@organizasyonId", DbType.Int32, organizasyonId);
			return db.ExecuteReader(dbComm);
		}

		public List<KatilimciOrganizasyonAratablo> GetByOrganizasyonIdList (string OrderBy,Int32 organizasyonId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ORGANIZASYON_ID,KATILIMCI_ID,KAYIT_NO from KATILIMCI_ORGANIZASYON_ARATABLO Where ORGANIZASYON_ID=@organizasyonId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@organizasyonId", DbType.Int32, organizasyonId);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<KatilimciOrganizasyonAratablo> katilimciorganizasyonaratabloList = new List<KatilimciOrganizasyonAratablo>();
				while(reader.Read()){
					KatilimciOrganizasyonAratablo katilimciorganizasyonaratablo = FillKatilimciOrganizasyonAratablo(reader);
					katilimciorganizasyonaratabloList.Add( katilimciorganizasyonaratablo);
				}
				return katilimciorganizasyonaratabloList;
			}
		}

		public int DeleteByOrganizasyonId(Int32 organizasyonId,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE KATILIMCI_ORGANIZASYON_ARATABLO where ORGANIZASYON_ID=@organizasyonId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@organizasyonId", DbType.Int32, organizasyonId);
			KatilimciOrganizasyonAratablo nesne=new KatilimciOrganizasyonAratablo();
			nesne.KatilimciId=-1;
			nesne.OrganizasyonId=organizasyonId;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}

		public DataSet GetByKatilimciId(string OrderBy,Int32 katilimciId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ORGANIZASYON_ID,KATILIMCI_ID,KAYIT_NO from KATILIMCI_ORGANIZASYON_ARATABLO Where KATILIMCI_ID=@katilimciId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@katilimciId", DbType.Int32, katilimciId);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetByKatilimciIdReader(string OrderBy,Int32 katilimciId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ORGANIZASYON_ID,KATILIMCI_ID,KAYIT_NO from KATILIMCI_ORGANIZASYON_ARATABLO Where KATILIMCI_ID=@katilimciId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@katilimciId", DbType.Int32, katilimciId);
			return db.ExecuteReader(dbComm);
		}

		public List<KatilimciOrganizasyonAratablo> GetByKatilimciIdList (string OrderBy,Int32 katilimciId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ORGANIZASYON_ID,KATILIMCI_ID,KAYIT_NO from KATILIMCI_ORGANIZASYON_ARATABLO Where KATILIMCI_ID=@katilimciId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@katilimciId", DbType.Int32, katilimciId);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<KatilimciOrganizasyonAratablo> katilimciorganizasyonaratabloList = new List<KatilimciOrganizasyonAratablo>();
				while(reader.Read()){
					KatilimciOrganizasyonAratablo katilimciorganizasyonaratablo = FillKatilimciOrganizasyonAratablo(reader);
					katilimciorganizasyonaratabloList.Add( katilimciorganizasyonaratablo);
				}
				return katilimciorganizasyonaratabloList;
			}
		}

		public int DeleteByKatilimciId(Int32 katilimciId,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE KATILIMCI_ORGANIZASYON_ARATABLO where KATILIMCI_ID=@katilimciId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@katilimciId", DbType.Int32, katilimciId);
			KatilimciOrganizasyonAratablo nesne=new KatilimciOrganizasyonAratablo();
			nesne.KatilimciId=-1;
			nesne.KatilimciId=katilimciId;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}
	}
}
