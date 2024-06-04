namespace DILifeCycleMVC.Services
{

    /*
     * Singleton: Tek instance -> constructor 1 kere çalışır
     * Transient: Her seferinde yeni instance 
     * Scoped: Her httpRequest'de yeni instance; aynı request içinde aynı instance
     */

    public interface IGuidGenerator
    {
        Guid Guid { get; set; }
    }

    public interface ISingleton : IGuidGenerator { }
    public interface ITransient : IGuidGenerator { }
    public interface IScoped: IGuidGenerator { }

    public class Singleton : ISingleton
    {
        public Guid Guid { get ; set; }
        public Singleton()
        {
            Guid = Guid.NewGuid();   
        }
    }

    public class Transient : ITransient
    {
        public Guid Guid { get; set; }
        public Transient()
        {
            Guid = Guid.NewGuid();
        }
    }

    public class Scoped : IScoped
    {
        public Guid Guid { get; set; }
        public Scoped()
        {
            Guid = Guid.NewGuid();
        }
    }

    public class GuidService
    {
        public ISingleton Singleton { get; set; }
        public ITransient Transient { get; set; }
        public IScoped Scoped { get; set; }

        public GuidService(ISingleton singleton, ITransient transient, IScoped scoped)
        {
            Singleton = singleton;
            Transient = transient;
            Scoped = scoped;
        }
    }


}
