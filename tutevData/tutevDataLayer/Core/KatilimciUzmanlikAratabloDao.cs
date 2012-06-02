using System; 
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using tutevDataLayer.Controller;

namespace tutevDataLayer.Core {

	public class KatilimciUzmanlikAratabloDao:BaseDbDao {

		private KatilimciUzmanlikAratablo nesne;
		private string sqlText;
		private string orderBy;
		private DbCommand dbComm = null;

		public KatilimciUzmanlikAratabloDao() {}

		public int Insert(KatilimciUzmanlikAratablo nesne,DbTransaction dbTransaction,Database db){
 			sqlText="INSERT INTO KATILIMCI_UZMANLIK_ARATABLO (KATILIMCI_ID,UZMANLIK_ALANI_ID)VALUES(@katilimciId,@uzmanlikAlaniId)SELECT @@IDENTITY";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@katilimciId", DbType.Int32, nesne.KatilimciId==null?(object)DBNull.Value:nesne.KatilimciId);
			db.AddInParameter(dbComm, "@uzmanlikAlaniId", DbType.Int32, nesne.UzmanlikAlaniId==null?(object)DBNull.Value:nesne.UzmanlikAlaniId);
			return base.Insert(nesne, dbComm, dbTransaction, db);
		}

		public int Update(KatilimciUzmanlikAratablo nesne,DbTransaction dbTransaction,Database db){
 			sqlText=" UPDATE KATILIMCI_UZMANLIK_ARATABLO set UZMANLIK_ALANI_ID = @uzmanlikAlaniId WHERE KATILIMCI_ID = @katilimciId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@katilimciId", DbType.Int32, nesne.KatilimciId==null?(object)DBNull.Value:nesne.KatilimciId);
			db.AddInParameter(dbComm, "@uzmanlikAlaniId", DbType.Int32, nesne.UzmanlikAlaniId==null?(object)DBNull.Value:nesne.UzmanlikAlaniId);
			return base.Update(nesne, dbComm, dbTransaction, db);
		}

		public int Delete(int katilimciId,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE KATILIMCI_UZMANLIK_ARATABLO where KATILIMCI_ID=@katilimciId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@katilimciId", DbType.Int32, katilimciId);
			KatilimciUzmanlikAratablo nesne = new KatilimciUzmanlikAratablo();
			nesne.KatilimciId = katilimciId;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}

		public KatilimciUzmanlikAratablo GetById(int katilimciId,Database db){
 			nesne = new KatilimciUzmanlikAratablo();
			sqlText="Select KATILIMCI_ID,UZMANLIK_ALANI_ID from KATILIMCI_UZMANLIK_ARATABLO where KATILIMCI_ID=@katilimciId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@katilimciId", DbType.Int32, katilimciId);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				if(reader.Read()){
					nesne = FillKatilimciUzmanlikAratablo(reader);
				}else nesne=null;
			}
			return nesne;
		}

		public DataSet GetAll(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select KATILIMCI_ID,UZMANLIK_ALANI_ID from KATILIMCI_UZMANLIK_ARATABLO "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetAllReader(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select KATILIMCI_ID,UZMANLIK_ALANI_ID from KATILIMCI_UZMANLIK_ARATABLO "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteReader(dbComm);
		}

		public List<KatilimciUzmanlikAratablo> GetAllList(string OrderBy,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select KATILIMCI_ID,UZMANLIK_ALANI_ID from KATILIMCI_UZMANLIK_ARATABLO "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<KatilimciUzmanlikAratablo> katilimciuzmanlikaratabloList = new List<KatilimciUzmanlikAratablo>();
				while(reader.Read()){
					KatilimciUzmanlikAratablo katilimciuzmanlikaratablo = FillKatilimciUzmanlikAratablo(reader);
					katilimciuzmanlikaratabloList.Add( katilimciuzmanlikaratablo);
				}
				return katilimciuzmanlikaratabloList;
			}
		}

		public DataSet GetByAll(string OrderBy,Int32 UzmanlikAlaniId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText=@"Select KATILIMCI_ID,UZMANLIK_ALANI_ID from KATILIMCI_UZMANLIK_ARATABLO Where 1=1 
 						 and (UZMANLIK_ALANI_ID = @uzmanlikAlaniId or @uzmanlikAlaniId =-1)
						"+orderBy;
			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@uzmanlikAlaniId", DbType.Int32, UzmanlikAlaniId);
			return db.ExecuteDataSet(dbComm);
		}


		public KatilimciUzmanlikAratablo FillKatilimciUzmanlikAratablo(IDataReader reader){
 			nesne = new KatilimciUzmanlikAratablo();
			nesne.KatilimciId=(Int32)reader["KATILIMCI_ID"];
			nesne.UzmanlikAlaniId=(Int32)reader["UZMANLIK_ALANI_ID"];
			return nesne;
		}

		public DataSet GetByKatilimciId(string OrderBy,Int32 katilimciId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select KATILIMCI_ID,UZMANLIK_ALANI_ID from KATILIMCI_UZMANLIK_ARATABLO Where KATILIMCI_ID=@katilimciId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@katilimciId", DbType.Int32, katilimciId);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetByKatilimciIdReader(string OrderBy,Int32 katilimciId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select KATILIMCI_ID,UZMANLIK_ALANI_ID from KATILIMCI_UZMANLIK_ARATABLO Where KATILIMCI_ID=@katilimciId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@katilimciId", DbType.Int32, katilimciId);
			return db.ExecuteReader(dbComm);
		}

		public List<KatilimciUzmanlikAratablo> GetByKatilimciIdList (string OrderBy,Int32 katilimciId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select KATILIMCI_ID,UZMANLIK_ALANI_ID from KATILIMCI_UZMANLIK_ARATABLO Where KATILIMCI_ID=@katilimciId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@katilimciId", DbType.Int32, katilimciId);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<KatilimciUzmanlikAratablo> katilimciuzmanlikaratabloList = new List<KatilimciUzmanlikAratablo>();
				while(reader.Read()){
					KatilimciUzmanlikAratablo katilimciuzmanlikaratablo = FillKatilimciUzmanlikAratablo(reader);
					katilimciuzmanlikaratabloList.Add( katilimciuzmanlikaratablo);
				}
				return katilimciuzmanlikaratabloList;
			}
		}

		public int DeleteByKatilimciId(Int32 katilimciId,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE KATILIMCI_UZMANLIK_ARATABLO where KATILIMCI_ID=@katilimciId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@katilimciId", DbType.Int32, katilimciId);
			KatilimciUzmanlikAratablo nesne=new KatilimciUzmanlikAratablo();
			nesne.KatilimciId=-1;
			nesne.KatilimciId=katilimciId;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}

		public DataSet GetByUzmanlikAlaniId(string OrderBy,Int32 uzmanlikAlaniId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select KATILIMCI_ID,UZMANLIK_ALANI_ID from KATILIMCI_UZMANLIK_ARATABLO Where UZMANLIK_ALANI_ID=@uzmanlikAlaniId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@uzmanlikAlaniId", DbType.Int32, uzmanlikAlaniId);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetByUzmanlikAlaniIdReader(string OrderBy,Int32 uzmanlikAlaniId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select KATILIMCI_ID,UZMANLIK_ALANI_ID from KATILIMCI_UZMANLIK_ARATABLO Where UZMANLIK_ALANI_ID=@uzmanlikAlaniId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@uzmanlikAlaniId", DbType.Int32, uzmanlikAlaniId);
			return db.ExecuteReader(dbComm);
		}

		public List<KatilimciUzmanlikAratablo> GetByUzmanlikAlaniIdList (string OrderBy,Int32 uzmanlikAlaniId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select KATILIMCI_ID,UZMANLIK_ALANI_ID from KATILIMCI_UZMANLIK_ARATABLO Where UZMANLIK_ALANI_ID=@uzmanlikAlaniId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@uzmanlikAlaniId", DbType.Int32, uzmanlikAlaniId);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<KatilimciUzmanlikAratablo> katilimciuzmanlikaratabloList = new List<KatilimciUzmanlikAratablo>();
				while(reader.Read()){
					KatilimciUzmanlikAratablo katilimciuzmanlikaratablo = FillKatilimciUzmanlikAratablo(reader);
					katilimciuzmanlikaratabloList.Add( katilimciuzmanlikaratablo);
				}
				return katilimciuzmanlikaratabloList;
			}
		}

		public int DeleteByUzmanlikAlaniId(Int32 uzmanlikAlaniId,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE KATILIMCI_UZMANLIK_ARATABLO where UZMANLIK_ALANI_ID=@uzmanlikAlaniId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@uzmanlikAlaniId", DbType.Int32, uzmanlikAlaniId);
			KatilimciUzmanlikAratablo nesne=new KatilimciUzmanlikAratablo();
			nesne.KatilimciId=-1;
			nesne.UzmanlikAlaniId=uzmanlikAlaniId;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}
	}
}
