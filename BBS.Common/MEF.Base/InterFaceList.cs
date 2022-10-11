using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

using BBS.Interface;

namespace BBS.Commom.MEF.Base
{
    [Export]
    public static class InterFaceList
    {
        [ImportMany]
        public static IEnumerable<Lazy<IUserService, InterfaceDepict>>? IUserServicesList { get; set; }
        [ImportMany]
        public static IEnumerable<Lazy<IArticleService, InterfaceDepict>>? IArticleServicesList { get; set; }

        /// <summary>
        /// MEF初始化依赖注入
        /// </summary>
        public static void Regisgter()
        {
            AggregateCatalog aggregateCatalog = new AggregateCatalog();
            var thisAssembly = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory, "BBS.*.dll");
            aggregateCatalog.Catalogs.Add(thisAssembly);
            var _container = new CompositionContainer(aggregateCatalog);
            _container.ComposeParts(thisAssembly);
        }

    }

    public interface InterfaceDepict
    {
        /// <summary>
        /// 元数据描述
        /// </summary>
        string Name { get; }
    }


}
