using System; 
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using tutevDataLayer.Controller;

namespace tutevDataLayer.Core {

	public class OrganizasyonTipDao:BaseDbDao {

		private OrganizasyonTip nesne;
		private string sqlText;
		private string orderBy;
		private DbCommand dbComm = null;

		public OrganizasyonTipDao() {}

		public int Insert(OrganizasyonTip nesne,DbTransaction dbTransaction,Database db){
 			sqlText="INSERT INTO ORGANIZASYON_TIP (ACIKLAMA)VALUES(@aciklama)SELECT @@IDENTITY";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@aciklama", DbType.String, nesne.Aciklama==null?(object)DBNull.Value:nesne.Aciklama);
			return base.Insert(nesne, dbComm, dbTransaction, db);
		}

		public int Update(OrganizasyonTip nesne,DbTransaction dbTransaction,Database db){
 			sqlText=" UPDATE ORGANIZASYON_TIP set ACIKLAMA = @aciklama WHERE ID = @id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, nesne.Id==null?(object)DBNull.Value:nesne.Id);
			db.AddInParameter(dbComm, "@aciklama", DbType.String, nesne.Aciklama==null?(object)DBNull.Value:nesne.Aciklama);
			return base.Update(nesne, dbComm, dbTransaction, db);
		}

		public int Delete(int id,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE ORGANIZASYON_TIP where ID=@id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, id);
			OrganizasyonTip nesne = new OrganizasyonTip();
			nesne.Id = id;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}

		public OrganizasyonTip GetById(int id,Database db){
 			nesne = new OrganizasyonTip();
			sqlText="Select ID,ACIKLAMA from ORGANIZASYON_TIP where ID=@id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, id);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				if(reader.Read()){
					nesne = FillOrganizasyonTip(reader);
				}else nesne=null;
			}
			return nesne;
		}

		public DataSet GetAll(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ACIKLAMA from ORGANIZASYON_TIP "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetAllReader(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ACIKLAMA from ORGANIZASYON_TIP "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteReader(dbComm);
		}

		public List<OrganizasyonTip> GetAllList(string OrderBy,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ACIKLAMA from ORGANIZASYON_TIP "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<OrganizasyonTip> organizasyontipList = new List<OrganizasyonTip>();
				while(reader.Read()){
					OrganizasyonTip organizasyontip = FillOrganizasyonTip(reader);
					organizasyontipList.Add( organizasyontip);
				}
				return organizasyontipList;
			}
		}

		public DataSet GetByAll(string OrderBy,String Aciklama,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText=@"Select ID,ACIKLAMA from ORGANIZASYON_TIP Where 1=1 
 						 and (ACIKLAMA like @aciklama or @aciklama ='')
						"+orderBy;
			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@aciklama", DbType.String, Aciklama);
			return db.ExecuteDataSet(dbComm);
		}


		public OrganizasyonTip FillOrganizasyonTip(IDataReader reader){
 			nesne = new OrganizasyonTip();
			nesne.Id=(Int32)reader["ID"];
			if(!(reader["ACIKLAMA"] is System.DBNull))nesne.Aciklama=(String)reader["ACIKLAMA"];
			return nesne;
		}
	}
}
