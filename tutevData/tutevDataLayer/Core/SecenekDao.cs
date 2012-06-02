using System; 
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using tutevDataLayer.Controller;

namespace tutevDataLayer.Core {

	public class SecenekDao:BaseDbDao {

		private Secenek nesne;
		private string sqlText;
		private string orderBy;
		private DbCommand dbComm = null;

		public SecenekDao() {}

		public int Insert(Secenek nesne,DbTransaction dbTransaction,Database db){
 			sqlText="INSERT INTO SECENEK (ACIKLAMA)VALUES(@aciklama)SELECT @@IDENTITY";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@aciklama", DbType.String, nesne.Aciklama==null?(object)DBNull.Value:nesne.Aciklama);
			return base.Insert(nesne, dbComm, dbTransaction, db);
		}

		public int Update(Secenek nesne,DbTransaction dbTransaction,Database db){
 			sqlText=" UPDATE SECENEK set ACIKLAMA = @aciklama WHERE ID = @id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, nesne.Id==null?(object)DBNull.Value:nesne.Id);
			db.AddInParameter(dbComm, "@aciklama", DbType.String, nesne.Aciklama==null?(object)DBNull.Value:nesne.Aciklama);
			return base.Update(nesne, dbComm, dbTransaction, db);
		}

		public int Delete(int id,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE SECENEK where ID=@id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, id);
			Secenek nesne = new Secenek();
			nesne.Id = id;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}

		public Secenek GetById(int id,Database db){
 			nesne = new Secenek();
			sqlText="Select ID,ACIKLAMA from SECENEK where ID=@id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, id);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				if(reader.Read()){
					nesne = FillSecenek(reader);
				}else nesne=null;
			}
			return nesne;
		}

		public DataSet GetAll(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ACIKLAMA from SECENEK "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetAllReader(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ACIKLAMA from SECENEK "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteReader(dbComm);
		}

		public List<Secenek> GetAllList(string OrderBy,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ACIKLAMA from SECENEK "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<Secenek> secenekList = new List<Secenek>();
				while(reader.Read()){
					Secenek secenek = FillSecenek(reader);
					secenekList.Add( secenek);
				}
				return secenekList;
			}
		}

		public DataSet GetByAll(string OrderBy,String Aciklama,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText=@"Select ID,ACIKLAMA from SECENEK Where 1=1 
 						 and (ACIKLAMA like @aciklama or @aciklama ='')
						"+orderBy;
			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@aciklama", DbType.String, Aciklama);
			return db.ExecuteDataSet(dbComm);
		}


		public Secenek FillSecenek(IDataReader reader){
 			nesne = new Secenek();
			nesne.Id=(Int32)reader["ID"];
			nesne.Aciklama=(String)reader["ACIKLAMA"];
			return nesne;
		}
	}
}
