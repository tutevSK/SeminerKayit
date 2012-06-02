using System; 
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using tutevDataLayer.Controller;

namespace tutevDataLayer.Core {

	public class UnvanDao:BaseDbDao {

		private Unvan nesne;
		private string sqlText;
		private string orderBy;
		private DbCommand dbComm = null;

		public UnvanDao() {}

		public int Insert(Unvan nesne,DbTransaction dbTransaction,Database db){
 			sqlText="INSERT INTO UNVAN (ACIKLAMA)VALUES(@aciklama)SELECT @@IDENTITY";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@aciklama", DbType.String, nesne.Aciklama==null?(object)DBNull.Value:nesne.Aciklama);
			return base.Insert(nesne, dbComm, dbTransaction, db);
		}

		public int Update(Unvan nesne,DbTransaction dbTransaction,Database db){
 			sqlText=" UPDATE UNVAN set ACIKLAMA = @aciklama WHERE ID = @id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, nesne.Id==null?(object)DBNull.Value:nesne.Id);
			db.AddInParameter(dbComm, "@aciklama", DbType.String, nesne.Aciklama==null?(object)DBNull.Value:nesne.Aciklama);
			return base.Update(nesne, dbComm, dbTransaction, db);
		}

		public int Delete(int id,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE UNVAN where ID=@id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, id);
			Unvan nesne = new Unvan();
			nesne.Id = id;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}

		public Unvan GetById(int id,Database db){
 			nesne = new Unvan();
			sqlText="Select ID,ACIKLAMA from UNVAN where ID=@id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, id);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				if(reader.Read()){
					nesne = FillUnvan(reader);
				}else nesne=null;
			}
			return nesne;
		}

		public DataSet GetAll(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ACIKLAMA from UNVAN "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetAllReader(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ACIKLAMA from UNVAN "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteReader(dbComm);
		}

		public List<Unvan> GetAllList(string OrderBy,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ACIKLAMA from UNVAN "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<Unvan> unvanList = new List<Unvan>();
				while(reader.Read()){
					Unvan unvan = FillUnvan(reader);
					unvanList.Add( unvan);
				}
				return unvanList;
			}
		}

		public DataSet GetByAll(string OrderBy,String Aciklama,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText=@"Select ID,ACIKLAMA from UNVAN Where 1=1 
 						 and (ACIKLAMA like @aciklama or @aciklama ='')
						"+orderBy;
			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@aciklama", DbType.String, Aciklama);
			return db.ExecuteDataSet(dbComm);
		}


		public Unvan FillUnvan(IDataReader reader){
 			nesne = new Unvan();
			nesne.Id=(Int32)reader["ID"];
			nesne.Aciklama=(String)reader["ACIKLAMA"];
			return nesne;
		}
	}
}
