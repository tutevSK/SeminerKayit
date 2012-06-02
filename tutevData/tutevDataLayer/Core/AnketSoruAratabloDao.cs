using System; 
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using tutevDataLayer.Controller;

namespace tutevDataLayer.Core {

	public class AnketSoruAratabloDao:BaseDbDao {

		private AnketSoruAratablo nesne;
		private string sqlText;
		private string orderBy;
		private DbCommand dbComm = null;

		public AnketSoruAratabloDao() {}

		public int Insert(AnketSoruAratablo nesne,DbTransaction dbTransaction,Database db){
 			sqlText="INSERT INTO ANKET_SORU_ARATABLO (ANKET_ID,SORU_ID)VALUES(@anketId,@soruId)SELECT @@IDENTITY";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@anketId", DbType.Int32, nesne.AnketId==null?(object)DBNull.Value:nesne.AnketId);
			db.AddInParameter(dbComm, "@soruId", DbType.Int32, nesne.SoruId==null?(object)DBNull.Value:nesne.SoruId);
			return base.Insert(nesne, dbComm, dbTransaction, db);
		}

		public int Update(AnketSoruAratablo nesne,DbTransaction dbTransaction,Database db){
 			sqlText=" UPDATE ANKET_SORU_ARATABLO set SORU_ID = @soruId WHERE ANKET_ID = @anketId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@anketId", DbType.Int32, nesne.AnketId==null?(object)DBNull.Value:nesne.AnketId);
			db.AddInParameter(dbComm, "@soruId", DbType.Int32, nesne.SoruId==null?(object)DBNull.Value:nesne.SoruId);
			return base.Update(nesne, dbComm, dbTransaction, db);
		}

		public int Delete(int anketId,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE ANKET_SORU_ARATABLO where ANKET_ID=@anketId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@anketId", DbType.Int32, anketId);
			AnketSoruAratablo nesne = new AnketSoruAratablo();
			nesne.AnketId = anketId;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}

		public AnketSoruAratablo GetById(int anketId,Database db){
 			nesne = new AnketSoruAratablo();
			sqlText="Select ANKET_ID,SORU_ID from ANKET_SORU_ARATABLO where ANKET_ID=@anketId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@anketId", DbType.Int32, anketId);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				if(reader.Read()){
					nesne = FillAnketSoruAratablo(reader);
				}else nesne=null;
			}
			return nesne;
		}

		public DataSet GetAll(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ANKET_ID,SORU_ID from ANKET_SORU_ARATABLO "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetAllReader(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ANKET_ID,SORU_ID from ANKET_SORU_ARATABLO "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteReader(dbComm);
		}

		public List<AnketSoruAratablo> GetAllList(string OrderBy,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ANKET_ID,SORU_ID from ANKET_SORU_ARATABLO "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<AnketSoruAratablo> anketsoruaratabloList = new List<AnketSoruAratablo>();
				while(reader.Read()){
					AnketSoruAratablo anketsoruaratablo = FillAnketSoruAratablo(reader);
					anketsoruaratabloList.Add( anketsoruaratablo);
				}
				return anketsoruaratabloList;
			}
		}

		public DataSet GetByAll(string OrderBy,Int32 SoruId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText=@"Select ANKET_ID,SORU_ID from ANKET_SORU_ARATABLO Where 1=1 
 						 and (SORU_ID = @soruId or @soruId =-1)
						"+orderBy;
			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@soruId", DbType.Int32, SoruId);
			return db.ExecuteDataSet(dbComm);
		}


		public AnketSoruAratablo FillAnketSoruAratablo(IDataReader reader){
 			nesne = new AnketSoruAratablo();
			nesne.AnketId=(Int32)reader["ANKET_ID"];
			nesne.SoruId=(Int32)reader["SORU_ID"];
			return nesne;
		}

		public DataSet GetByAnketId(string OrderBy,Int32 anketId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ANKET_ID,SORU_ID from ANKET_SORU_ARATABLO Where ANKET_ID=@anketId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@anketId", DbType.Int32, anketId);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetByAnketIdReader(string OrderBy,Int32 anketId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ANKET_ID,SORU_ID from ANKET_SORU_ARATABLO Where ANKET_ID=@anketId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@anketId", DbType.Int32, anketId);
			return db.ExecuteReader(dbComm);
		}

		public List<AnketSoruAratablo> GetByAnketIdList (string OrderBy,Int32 anketId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ANKET_ID,SORU_ID from ANKET_SORU_ARATABLO Where ANKET_ID=@anketId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@anketId", DbType.Int32, anketId);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<AnketSoruAratablo> anketsoruaratabloList = new List<AnketSoruAratablo>();
				while(reader.Read()){
					AnketSoruAratablo anketsoruaratablo = FillAnketSoruAratablo(reader);
					anketsoruaratabloList.Add( anketsoruaratablo);
				}
				return anketsoruaratabloList;
			}
		}

		public int DeleteByAnketId(Int32 anketId,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE ANKET_SORU_ARATABLO where ANKET_ID=@anketId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@anketId", DbType.Int32, anketId);
			AnketSoruAratablo nesne=new AnketSoruAratablo();
			nesne.AnketId=-1;
			nesne.AnketId=anketId;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}

		public DataSet GetBySoruId(string OrderBy,Int32 soruId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ANKET_ID,SORU_ID from ANKET_SORU_ARATABLO Where SORU_ID=@soruId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@soruId", DbType.Int32, soruId);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetBySoruIdReader(string OrderBy,Int32 soruId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ANKET_ID,SORU_ID from ANKET_SORU_ARATABLO Where SORU_ID=@soruId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@soruId", DbType.Int32, soruId);
			return db.ExecuteReader(dbComm);
		}

		public List<AnketSoruAratablo> GetBySoruIdList (string OrderBy,Int32 soruId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ANKET_ID,SORU_ID from ANKET_SORU_ARATABLO Where SORU_ID=@soruId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@soruId", DbType.Int32, soruId);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<AnketSoruAratablo> anketsoruaratabloList = new List<AnketSoruAratablo>();
				while(reader.Read()){
					AnketSoruAratablo anketsoruaratablo = FillAnketSoruAratablo(reader);
					anketsoruaratabloList.Add( anketsoruaratablo);
				}
				return anketsoruaratabloList;
			}
		}

		public int DeleteBySoruId(Int32 soruId,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE ANKET_SORU_ARATABLO where SORU_ID=@soruId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@soruId", DbType.Int32, soruId);
			AnketSoruAratablo nesne=new AnketSoruAratablo();
			nesne.AnketId=-1;
			nesne.SoruId=soruId;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}
	}
}
