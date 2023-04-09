using BLL.Entities.Innosilicon.Emulation;

namespace BLL.Entities
{
    internal class EmulatorStorage
    {
        /*
        TODO:
        потом надо ввести общий интерфейс для эмуляторов
        */

        private static EmulatorStorage _emulatorStorage;

        public static EmulatorStorage Instance()
        {
            if (_emulatorStorage != null)
                return _emulatorStorage;
            else
            {
                _emulatorStorage = new EmulatorStorage();
                return _emulatorStorage;
            }
        }

        public int InnosiliconEmulatorCount
        {
            get { return _innosiliconEmulators.Where(x => x is InnosiliconEmulator).Count(); }
        }

        private List<InnosiliconEmulator> _innosiliconEmulators;
        /// <summary>
        /// Список объектов для эмуляции работы асиков
        /// </summary>
        public List<InnosiliconEmulator> InnosiliconEmulators
        {
            get { return new List<InnosiliconEmulator>(_innosiliconEmulators); }
            private set { _innosiliconEmulators = value; }
        }

        public EmulatorStorage()
        {
            _innosiliconEmulators = new List<InnosiliconEmulator>();
        }

        public List<Device> GetDevices()
        {
            List<Device> devices = new List<Device>();
            foreach (InnosiliconEmulator innosiliconEmulator in InnosiliconEmulators)
            {
                devices.Add(new Device() { Ip = innosiliconEmulator.Ip, Type = innosiliconEmulator.Type });
            }
            return devices;
        }

        public void Add(InnosiliconEmulator innosiliconEmulator)
        {
            _innosiliconEmulators.Add(innosiliconEmulator);
        }

        public InnosiliconEmulator FindByIp(string ip)
        {
            return InnosiliconEmulators.Find(x => x.Ip.Equals(ip));
        }

        public void Remove(InnosiliconEmulator innosiliconEmulator)
        {
            _innosiliconEmulators.Remove(innosiliconEmulator);
        }

        public InnosiliconEmulator Last()
        {
            return _innosiliconEmulators.Last();
        }
    }
}
