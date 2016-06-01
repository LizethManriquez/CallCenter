
using Globals;
using Softv.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace SoftvWCFService.Contracts
{
    [ServiceContract]
    public interface IPermiso
    {
        [OperationContract]
        PermisoEntity GetPermiso(int? IdRol);

        [OperationContract]
        PermisoEntity GetDeepPermiso(int? IdRol, int? IdModule);

        [OperationContract]
        IEnumerable<PermisoEntity> GetPermisoList();

        [OperationContract]
        SoftvList<PermisoEntity> GetPermisoPagedList(int page, int pageSize);

        [OperationContract]
        SoftvList<PermisoEntity> GetPermisoPagedListXml(int page, int pageSize, String xml);

        [OperationContract]
        int AddPermiso(PermisoEntity objPermiso);

        [OperationContract]
        int UpdatePermiso(PermisoEntity objPermiso);

        [OperationContract]
        int DeletePermiso(String BaseRemoteIp, int BaseIdUser, int? IdRol);

        [OperationContract]
        SoftvList<PermisoEntity> GetXmlPermiso(String xml);

        [OperationContract]
        int MargePermiso(int BaseIdUser, String BaseRemoteIp, String xml);

    }
}

