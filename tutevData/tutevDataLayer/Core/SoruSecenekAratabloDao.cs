using System; 
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using tutevDataLayer.Controller;

namespace tutevDataLayer.Core {

	public class SoruSecenekAratabloDao:BaseDbDao {

		private SoruSecenekAratablo nesne;
		private string sqlText;
		private string orderBy;
		private DbCommand dbComm = null;

		public SoruSecenekAratabloDao() {}

		public int Insert(SoruSecenekAratablo nesne,DbTransaction dbTransaction,Database db){
 			sqlText="INSERT INTO SORU_SECENEK_ARATABLO (SORU_ID,SECENEK_ID)VALUES(@soruId,@secenekId)SELECT @@IDENTITY";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@soruId", DbType.Int32, nesne.SoruId==null?(object)DBNull.Value:nesne.SoruId);
			db.AddInParameter(dbComm, "@secenekId", DbType.Int32, nesne.SecenekId==null?(object)DBNull.Value:nesne.SecenekId);
			return base.Insert(nesne, dbComm, dbTransaction, db);
		}

		public int Update(SoruSecenekAratablo nesne,DbTransaction dbTransaction,Database db){
 			sqlText=" UPDATE SORU_SECENEK_ARATABLO set SORU_ID = @soruId WHERE SECENEK_ID = @secenekId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@soruId", DbType.Int32, nesne.SoruId==null?(object)DBNull.Value:nesne.SoruId);
			db.AddInParameter(dbComm, "@secenekId", DbType.Int32, nesne.SecenekId==null?(object)DBNull.Value:nesne.SecenekId);
			return base.Update(nesne, dbComm, dbTransaction, db);
		}

		public int Delete(int secenekId,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE SORU_SECENEK_ARATABLO where SECENEK_ID=@secenekId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@secenekId", DbType.Int32, secenekId);
			SoruSecenekAratablo nesne = new SoruSecenekAratablo();
			nesne.SecenekId = secenekId;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}

		public SoruSecenekAratablo GetById(int secenekId,Database db){
 			nesne = new SoruSecenekAratablo();
			sqlText="Select SORU_ID,SECENEK_ID from SORU_SECENEK_ARATABLO where SECENEK_ID=@secenekId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@secenekId", DbType.Int32, secenekId);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				if(reader.Read()){
					nesne = FillSoruSecenekAratablo(reader);
				}else nesne=null;
			}
			return nesne;
		}

		public DataSet GetAll(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select SORU_ID,SECENEK_ID from SORU_SECENEK_ARATABLO "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetAllReader(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select SORU_ID,SECENEK_ID from SORU_SECENEK_ARATABLO "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteReader(dbComm);
		}

		public List<SoruSecenekAratablo> GetAllList(string OrderBy,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select SORU_ID,SECENEK_ID from SORU_SECENEK_ARATABLO "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<SoruSecenekAratablo> sorusecenekaratabloList = new List<SoruSecenekAratablo>();
				while(reader.Read()){
					SoruSecenekAratablo sorusecenekaratablo = FillSoruSecenekAratablo(reader);
					sorusecenekaratabloList.Add( sorusecenekaratablo);
				}
				return sorusecenekaratabloList;
			}
		}

		public DataSet GetByAll(string OrderBy,Int32 SoruId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText=@"Select SORU_ID,SECENEK_ID from SORU_SECENEK_ARATABLO Where 1=1 
 						 and (SORU_ID = @soruId or @soruId =-1)
						"+orderBy;
			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@soruId", DbType.Int32, SoruId);
			return db.ExecuteDataSet(dbComm);
		}


		public SoruSecenekAratablo FillSoruSecenekAratablo(IDataReader reader){
 			nesne = new SoruSecenekAratablo();
			nesne.SoruId=(Int32)reader["SORU_ID"];
			nesne.SecenekId=(Int32)reader["SECENEK_ID"];
			return nesne;
		}

		public DataSet GetBySoruId(string OrderBy,Int32 soruId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select SORU_ID,SECENEK_ID from SORU_SECENEK_ARATABLO Where SORU_ID=@soruId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@soruId", DbType.Int32, soruId);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetBySoruIdReader(string OrderBy,Int32 soruId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select SORU_ID,SECENEK_ID from SORU_SECENEK_ARATABLO Where SORU_ID=@soruId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@soruId", DbType.Int32, soruId);
			return db.ExecuteReader(dbComm);
		}

		public List<SoruSecenekAratablo> GetBySoruIdList (string OrderBy,Int32 soruId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select SORU_ID,SECENEK_ID from SORU_SECENEK_ARATABLO Where SORU_ID=@soruId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@soruId", DbType.Int32, soruId);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<SoruSecenekAratablo> sorusecenekaratabloList = new List<SoruSecenekAratablo>();
				while(reader.Read()){
					SoruSecenekAratablo sorusecenekaratablo = FillSoruSecenekAratablo(reader);
					sorusecenekaratabloList.Add( sorusecenekaratablo);
				}
				return sorusecenekaratabloList;
			}
		}

		public int DeleteBySoruId(Int32 soruId,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE SORU_SECENEK_ARATABLO where SORU_ID=@soruId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@soruId", DbType.Int32, soruId);
			SoruSecenekAratablo nesne=new SoruSecenekAratablo();
			nesne.SecenekId=-1;
			nesne.SoruId=soruId;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}

		public DataSet GetBySecenekId(string OrderBy,Int32 secenekId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select SORU_ID,SECENEK_ID from SORU_SECENEK_ARATABLO Where SECENEK_ID=@secenekId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@secenekId", DbType.Int32, secenekId);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetBySecenekIdReader(string OrderBy,Int32 secenekId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select SORU_ID,SECENEK_ID from SORU_SECENEK_ARATABLO Where SECENEK_ID=@secenekId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@secenekId", DbType.Int32, secenekId);
			return db.ExecuteReader(dbComm);
		}

		public List<SoruSecenekAratablo> GetBySecenekIdList (string OrderBy,Int32 secenekId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select SORU_ID,SECENEK_ID from SORU_SECENEK_ARATABLO Where SECENEK_ID=@secenekId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@secenekId", DbType.Int32, secenekId);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<SoruSecenekAratablo> sorusecenekaratabloList = new List<SoruSecenekAratablo>();
				while(reader.Read()){
					SoruSecenekAratablo sorusecenekaratablo = FillSoruSecenekAratablo(reader);
					sorusecenekaratabloList.Add( sorusecenekaratablo);
				}
				return sorusecenekaratabloList;
			}
		}

		public int DeleteBySecenekId(Int32 secenekId,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE SORU_SECENEK_ARATABLO where SECENEK_ID=@secenekId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@secenekId", DbType.Int32, secenekId);
			SoruSecenekAratablo nesne=new SoruSecenekAratablo();
			nesne.SecenekId=-1;
			nesne.SecenekId=secenekId;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}
	}
}
