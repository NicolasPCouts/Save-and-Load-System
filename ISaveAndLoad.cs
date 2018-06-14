using System;

namespace survivalPrototype
{
	public interface ISaveAndLoad
	{
		void Save(int indexToSave);
		void Load(int indexToLoad);
	}
}

