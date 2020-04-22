

using System;

namespace Infrastructure.EntityMode
{
  public  struct Foundation
    {
        public string TowerName;
        /// <summary>基础类型</summary>
        public string Type;
        public double volume;

        public Foundation(string towerName, string type, double volume)
        {
            TowerName = towerName ?? throw new ArgumentNullException(nameof(towerName));
            Type = type ?? throw new ArgumentNullException(nameof(type));
            this.volume = volume;
        }
    }
}
