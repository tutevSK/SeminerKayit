using System; 
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using tutevDataLayer.Controller;

namespace tutevDataLayer.Core {

	public class DuyuruTipDao:BaseDbDao {

		private DuyuruTip nesne;
		private string sqlText;
		private string orderBy;
		private DbCommand dbComm = null;

		public DuyuruTipDao() {}

		public int Insert(DuyuruTip nesne,DbTransaction dbTransaction,Database db){
 			sqlText="INSERT INTO DUYURU_TIP (ACIKLAMA)VALUES(@aciklama)SELECT @@IDENTITY";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@aciklama", DbType.String, nesne.Aciklama==null?(object)DBNull.Value:nesne.Aciklama);
			return base.Insert(nesne, dbComm, dbTransaction, db);
		}

		public int Update(DuyuruTip nesne,DbTransaction dbTransaction,Database db){
 			sqlText=" UPDATE DUYURU_TIP set ACIKLAMA = @aciklama WHERE ID = @id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, nesne.Id==null?(object)DBNull.Value:nesne.Id);
			db.AddInParameter(dbComm, "@aciklama", DbType.String, nesne.Aciklama==null?(object)DBNull.Value:nesne.Aciklama);
			return base.Update(nesne, dbComm, dbTransaction, db);
		}

		public int Delete(int id,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE DUYURU_TIP where ID=@id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, id);
			DuyuruTip nesne = new DuyuruTip();
			nesne.Id = id;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}

		public DuyuruTip GetById(int id,Database db){
 			nesne = new DuyuruTip();
			sqlText="Select ID,ACIKLAMA from DUYURU_TIP where ID=@id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, id);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				if(reader.Read()){
					nesne = FillDuyuruTip(reader);
				}else nesne=null;
			}
			return nesne;
		}

		public DataSet GetAll(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ACIKLAMA from DUYURU_TIP "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetAllReader(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ACIKLAMA from DUYURU_TIP "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteReader(dbComm);
		}

		public List<DuyuruTip> GetAllList(string OrderBy,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ACIKLAMA from DUYURU_TIP "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<DuyuruTip> duyurutipList = new List<DuyuruTip>();
				while(reader.Read()){
					DuyuruTip duyurutip = FillDuyuruTip(reader);
					duyurutipList.Add( duyurutip);
				}
				return duyurutipList;
			}
		}

		public DataSet GetByAll(string OrderBy,String Aciklama,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText=@"Select ID,ACIKLAMA from DUYURU_TIP Where 1=1 
 						 and (ACIKLAMA like @aciklama or @aciklama ='')
						"+orderBy;
			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@aciklama", DbType.String, Aciklama);
			return db.ExecuteDataSet(dbComm);
		}


		public DuyuruTip FillDuyuruTip(IDataReader reader){
 			nesne = new DuyuruTip();
			nesne.Id=(Int32)reader["ID"];
			nesne.Aciklama=(String)reader["ACIKLAMA"];
			return nesne;
		}
	}
}
