using System; 
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using tutevDataLayer.Controller;

namespace tutevDataLayer.Core {

	public class KatilimciAnketCevapAratabloDao:BaseDbDao {

		private KatilimciAnketCevapAratablo nesne;
		private string sqlText;
		private string orderBy;
		private DbCommand dbComm = null;

		public KatilimciAnketCevapAratabloDao() {}

		public int Insert(KatilimciAnketCevapAratablo nesne,DbTransaction dbTransaction,Database db){
 			sqlText="INSERT INTO KATILIMCI_ANKET_CEVAP_ARATABLO (KATILIMCI_ID,SORU_ID,SECENEK_ID)VALUES(@katilimciId,@soruId,@secenekId)SELECT @@IDENTITY";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@katilimciId", DbType.Int32, nesne.KatilimciId==null?(object)DBNull.Value:nesne.KatilimciId);
			db.AddInParameter(dbComm, "@soruId", DbType.Int32, nesne.SoruId==null?(object)DBNull.Value:nesne.SoruId);
			db.AddInParameter(dbComm, "@secenekId", DbType.Int32, nesne.SecenekId==null?(object)DBNull.Value:nesne.SecenekId);
			return base.Insert(nesne, dbComm, dbTransaction, db);
		}

		public int Update(KatilimciAnketCevapAratablo nesne,DbTransaction dbTransaction,Database db){
 			sqlText=" UPDATE KATILIMCI_ANKET_CEVAP_ARATABLO set SORU_ID = @soruId , SECENEK_ID = @secenekId WHERE KATILIMCI_ID = @katilimciId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@katilimciId", DbType.Int32, nesne.KatilimciId==null?(object)DBNull.Value:nesne.KatilimciId);
			db.AddInParameter(dbComm, "@soruId", DbType.Int32, nesne.SoruId==null?(object)DBNull.Value:nesne.SoruId);
			db.AddInParameter(dbComm, "@secenekId", DbType.Int32, nesne.SecenekId==null?(object)DBNull.Value:nesne.SecenekId);
			return base.Update(nesne, dbComm, dbTransaction, db);
		}

		public int Delete(int katilimciId,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE KATILIMCI_ANKET_CEVAP_ARATABLO where KATILIMCI_ID=@katilimciId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@katilimciId", DbType.Int32, katilimciId);
			KatilimciAnketCevapAratablo nesne = new KatilimciAnketCevapAratablo();
			nesne.KatilimciId = katilimciId;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}

		public KatilimciAnketCevapAratablo GetById(int katilimciId,Database db){
 			nesne = new KatilimciAnketCevapAratablo();
			sqlText="Select KATILIMCI_ID,SORU_ID,SECENEK_ID from KATILIMCI_ANKET_CEVAP_ARATABLO where KATILIMCI_ID=@katilimciId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@katilimciId", DbType.Int32, katilimciId);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				if(reader.Read()){
					nesne = FillKatilimciAnketCevapAratablo(reader);
				}else nesne=null;
			}
			return nesne;
		}

		public DataSet GetAll(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select KATILIMCI_ID,SORU_ID,SECENEK_ID from KATILIMCI_ANKET_CEVAP_ARATABLO "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetAllReader(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select KATILIMCI_ID,SORU_ID,SECENEK_ID from KATILIMCI_ANKET_CEVAP_ARATABLO "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteReader(dbComm);
		}

		public List<KatilimciAnketCevapAratablo> GetAllList(string OrderBy,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select KATILIMCI_ID,SORU_ID,SECENEK_ID from KATILIMCI_ANKET_CEVAP_ARATABLO "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<KatilimciAnketCevapAratablo> katilimcianketcevaparatabloList = new List<KatilimciAnketCevapAratablo>();
				while(reader.Read()){
					KatilimciAnketCevapAratablo katilimcianketcevaparatablo = FillKatilimciAnketCevapAratablo(reader);
					katilimcianketcevaparatabloList.Add( katilimcianketcevaparatablo);
				}
				return katilimcianketcevaparatabloList;
			}
		}

		public DataSet GetByAll(string OrderBy,Int32 SoruId,Int32 SecenekId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText=@"Select KATILIMCI_ID,SORU_ID,SECENEK_ID from KATILIMCI_ANKET_CEVAP_ARATABLO Where 1=1 
 						 and (SORU_ID = @soruId or @soruId =-1)
						 and (SECENEK_ID = @secenekId or @secenekId =-1)
						"+orderBy;
			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@soruId", DbType.Int32, SoruId);
			db.AddInParameter(dbComm, "@secenekId", DbType.Int32, SecenekId);
			return db.ExecuteDataSet(dbComm);
		}


		public KatilimciAnketCevapAratablo FillKatilimciAnketCevapAratablo(IDataReader reader){
 			nesne = new KatilimciAnketCevapAratablo();
			nesne.KatilimciId=(Int32)reader["KATILIMCI_ID"];
			nesne.SoruId=(Int32)reader["SORU_ID"];
			nesne.SecenekId=(Int32)reader["SECENEK_ID"];
			return nesne;
		}

		public DataSet GetByKatilimciId(string OrderBy,Int32 katilimciId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select KATILIMCI_ID,SORU_ID,SECENEK_ID from KATILIMCI_ANKET_CEVAP_ARATABLO Where KATILIMCI_ID=@katilimciId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@katilimciId", DbType.Int32, katilimciId);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetByKatilimciIdReader(string OrderBy,Int32 katilimciId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select KATILIMCI_ID,SORU_ID,SECENEK_ID from KATILIMCI_ANKET_CEVAP_ARATABLO Where KATILIMCI_ID=@katilimciId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@katilimciId", DbType.Int32, katilimciId);
			return db.ExecuteReader(dbComm);
		}

		public List<KatilimciAnketCevapAratablo> GetByKatilimciIdList (string OrderBy,Int32 katilimciId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select KATILIMCI_ID,SORU_ID,SECENEK_ID from KATILIMCI_ANKET_CEVAP_ARATABLO Where KATILIMCI_ID=@katilimciId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@katilimciId", DbType.Int32, katilimciId);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<KatilimciAnketCevapAratablo> katilimcianketcevaparatabloList = new List<KatilimciAnketCevapAratablo>();
				while(reader.Read()){
					KatilimciAnketCevapAratablo katilimcianketcevaparatablo = FillKatilimciAnketCevapAratablo(reader);
					katilimcianketcevaparatabloList.Add( katilimcianketcevaparatablo);
				}
				return katilimcianketcevaparatabloList;
			}
		}

		public int DeleteByKatilimciId(Int32 katilimciId,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE KATILIMCI_ANKET_CEVAP_ARATABLO where KATILIMCI_ID=@katilimciId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@katilimciId", DbType.Int32, katilimciId);
			KatilimciAnketCevapAratablo nesne=new KatilimciAnketCevapAratablo();
			nesne.KatilimciId=-1;
			nesne.KatilimciId=katilimciId;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}

		public DataSet GetBySoruId(string OrderBy,Int32 soruId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select KATILIMCI_ID,SORU_ID,SECENEK_ID from KATILIMCI_ANKET_CEVAP_ARATABLO Where SORU_ID=@soruId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@soruId", DbType.Int32, soruId);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetBySoruIdReader(string OrderBy,Int32 soruId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select KATILIMCI_ID,SORU_ID,SECENEK_ID from KATILIMCI_ANKET_CEVAP_ARATABLO Where SORU_ID=@soruId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@soruId", DbType.Int32, soruId);
			return db.ExecuteReader(dbComm);
		}

		public List<KatilimciAnketCevapAratablo> GetBySoruIdList (string OrderBy,Int32 soruId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select KATILIMCI_ID,SORU_ID,SECENEK_ID from KATILIMCI_ANKET_CEVAP_ARATABLO Where SORU_ID=@soruId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@soruId", DbType.Int32, soruId);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<KatilimciAnketCevapAratablo> katilimcianketcevaparatabloList = new List<KatilimciAnketCevapAratablo>();
				while(reader.Read()){
					KatilimciAnketCevapAratablo katilimcianketcevaparatablo = FillKatilimciAnketCevapAratablo(reader);
					katilimcianketcevaparatabloList.Add( katilimcianketcevaparatablo);
				}
				return katilimcianketcevaparatabloList;
			}
		}

		public int DeleteBySoruId(Int32 soruId,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE KATILIMCI_ANKET_CEVAP_ARATABLO where SORU_ID=@soruId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@soruId", DbType.Int32, soruId);
			KatilimciAnketCevapAratablo nesne=new KatilimciAnketCevapAratablo();
			nesne.KatilimciId=-1;
			nesne.SoruId=soruId;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}

		public DataSet GetBySecenekId(string OrderBy,Int32 secenekId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select KATILIMCI_ID,SORU_ID,SECENEK_ID from KATILIMCI_ANKET_CEVAP_ARATABLO Where SECENEK_ID=@secenekId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@secenekId", DbType.Int32, secenekId);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetBySecenekIdReader(string OrderBy,Int32 secenekId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select KATILIMCI_ID,SORU_ID,SECENEK_ID from KATILIMCI_ANKET_CEVAP_ARATABLO Where SECENEK_ID=@secenekId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@secenekId", DbType.Int32, secenekId);
			return db.ExecuteReader(dbComm);
		}

		public List<KatilimciAnketCevapAratablo> GetBySecenekIdList (string OrderBy,Int32 secenekId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select KATILIMCI_ID,SORU_ID,SECENEK_ID from KATILIMCI_ANKET_CEVAP_ARATABLO Where SECENEK_ID=@secenekId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@secenekId", DbType.Int32, secenekId);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<KatilimciAnketCevapAratablo> katilimcianketcevaparatabloList = new List<KatilimciAnketCevapAratablo>();
				while(reader.Read()){
					KatilimciAnketCevapAratablo katilimcianketcevaparatablo = FillKatilimciAnketCevapAratablo(reader);
					katilimcianketcevaparatabloList.Add( katilimcianketcevaparatablo);
				}
				return katilimcianketcevaparatabloList;
			}
		}

		public int DeleteBySecenekId(Int32 secenekId,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE KATILIMCI_ANKET_CEVAP_ARATABLO where SECENEK_ID=@secenekId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@secenekId", DbType.Int32, secenekId);
			KatilimciAnketCevapAratablo nesne=new KatilimciAnketCevapAratablo();
			nesne.KatilimciId=-1;
			nesne.SecenekId=secenekId;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}
	}
}
