using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

using BBS.Interface;

namespace BBS.Commom.MEF.Base
{

    public static class InterFaceList
    {

        public static  IEnumerable<Lazy<IUserService, InterfaceDepict>>? IUserServicesList { get; set; }
        public static IEnumerable<Lazy<IArticleService, InterfaceDepict>>? IArticleServicesList { get; set; }
        /// <summary>
        /// MEF初始化依赖注入
        /// </summary>
        public static void Regisgter()
        {

            RegisterMode registerMode = new RegisterMode();
            registerMode.Regisgter();
            IUserServicesList = registerMode.IUserServicesList;
            IArticleServicesList= registerMode.IArticleServicesList;
        }

    }

    public interface InterfaceDepict
    {
        /// <summary>
        /// 元数据描述
        /// </summary>
        string Name { get; }
    }

    [Export]
    public class RegisterMode
    {

        [ImportMany(typeof(IUserService))]
        public IEnumerable<Lazy<IUserService, InterfaceDepict>> IUserServicesList { get; set; }
        [ImportMany(typeof(IArticleService))]
        public IEnumerable<Lazy<IArticleService, InterfaceDepict>> IArticleServicesList { get; set; }

        public void Regisgter()
        {
            AggregateCatalog aggregateCatalog = new AggregateCatalog();
            var thisAssembly = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory, "BBS.*.dll");
            aggregateCatalog.Catalogs.Add(thisAssembly);
            var _container = new CompositionContainer(aggregateCatalog);
            _container.ComposeParts(this);
        }

    }


}
