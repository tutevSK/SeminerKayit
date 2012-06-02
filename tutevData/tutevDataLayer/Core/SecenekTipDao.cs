using System; 
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using tutevDataLayer.Controller;

namespace tutevDataLayer.Core {

	public class SecenekTipDao:BaseDbDao {

		private SecenekTip nesne;
		private string sqlText;
		private string orderBy;
		private DbCommand dbComm = null;

		public SecenekTipDao() {}

		public int Insert(SecenekTip nesne,DbTransaction dbTransaction,Database db){
 			sqlText="INSERT INTO SECENEK_TIP (ACIKLAMA)VALUES(@aciklama)SELECT @@IDENTITY";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@aciklama", DbType.String, nesne.Aciklama==null?(object)DBNull.Value:nesne.Aciklama);
			return base.Insert(nesne, dbComm, dbTransaction, db);
		}

		public int Update(SecenekTip nesne,DbTransaction dbTransaction,Database db){
 			sqlText=" UPDATE SECENEK_TIP set ACIKLAMA = @aciklama WHERE ID = @id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, nesne.Id==null?(object)DBNull.Value:nesne.Id);
			db.AddInParameter(dbComm, "@aciklama", DbType.String, nesne.Aciklama==null?(object)DBNull.Value:nesne.Aciklama);
			return base.Update(nesne, dbComm, dbTransaction, db);
		}

		public int Delete(int id,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE SECENEK_TIP where ID=@id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, id);
			SecenekTip nesne = new SecenekTip();
			nesne.Id = id;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}

		public SecenekTip GetById(int id,Database db){
 			nesne = new SecenekTip();
			sqlText="Select ID,ACIKLAMA from SECENEK_TIP where ID=@id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, id);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				if(reader.Read()){
					nesne = FillSecenekTip(reader);
				}else nesne=null;
			}
			return nesne;
		}

		public DataSet GetAll(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ACIKLAMA from SECENEK_TIP "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetAllReader(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ACIKLAMA from SECENEK_TIP "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteReader(dbComm);
		}

		public List<SecenekTip> GetAllList(string OrderBy,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ACIKLAMA from SECENEK_TIP "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<SecenekTip> secenektipList = new List<SecenekTip>();
				while(reader.Read()){
					SecenekTip secenektip = FillSecenekTip(reader);
					secenektipList.Add( secenektip);
				}
				return secenektipList;
			}
		}

		public DataSet GetByAll(string OrderBy,String Aciklama,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText=@"Select ID,ACIKLAMA from SECENEK_TIP Where 1=1 
 						 and (ACIKLAMA like @aciklama or @aciklama ='')
						"+orderBy;
			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@aciklama", DbType.String, Aciklama);
			return db.ExecuteDataSet(dbComm);
		}


		public SecenekTip FillSecenekTip(IDataReader reader){
 			nesne = new SecenekTip();
			nesne.Id=(Int32)reader["ID"];
			nesne.Aciklama=(String)reader["ACIKLAMA"];
			return nesne;
		}
	}
}
