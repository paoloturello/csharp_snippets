using System.Collections.Generic;
using System.Linq;

public class SteinhausJohnsonTrotterPermute
{
	private int _Count;
	private int[] _List;
	private bool[] _Directions;

	public IEnumerable<IEnumerable<int>> Permute(int count)
	{
		Initialize(count);
		return Permute();
	}

	public IEnumerable<IEnumerable<T>> Permute<T>(IEnumerable<T> list)
	{
		Initialize(list.Count());
		foreach (var permutation in Permute())
		{
			yield return permutation.Select(p => list.ElementAt(p));
		}
	}

	private IEnumerable<IEnumerable<int>> Permute()
	{
		yield return _List;

		int mobileIndex;
		int mobileValue;
		while (GetNextMobileInteger(out mobileIndex))
		{
			mobileValue = _List[mobileIndex];
			Swap(mobileIndex);
			yield return _List;

			ChangeDirectionsGreaterThan(mobileValue);
		}
	}

	private void Initialize(int count)
	{
		_Count = count;
		_List = new int[count];
		_Directions = new bool[count];
		for (int i = 0; i < count; i++)
		{
			_List[i] = i;
			_Directions[i] = false;
		}
	}

	private bool GetNextMobileInteger(out int mobileIntegerIndex)
	{
		mobileIntegerIndex = -1;

		for (int current = 0; current < _Count; current++)
		{
			if (IsMobile(current) && (mobileIntegerIndex == -1 || _List[current] > _List[mobileIntegerIndex]))
			{
				mobileIntegerIndex = current;
			}
		}

		return mobileIntegerIndex >= 0;
	}

	private bool IsMobile(int index)
	{
		if (index == 0 && !_Directions[0])
		{
			return false;
		}

		if (index == _Count - 1 && _Directions[_Count - 1])
		{
			return false;
		}

		return _List[index] > _List[index + (_Directions[index] ? 1 : -1)];
	}

	private void Swap(int index)
	{
		int delta = _Directions[index] ? 1 : -1;
		int tmp = _List[index + delta];
		_List[index + delta] = _List[index];
		_List[index] = tmp;

		bool dtmp = _Directions[index + delta];
		_Directions[index + delta] = _Directions[index];
		_Directions[index] = dtmp;
	}

	private void ChangeDirectionsGreaterThan(int mobileValue)
	{
		for (int i = 0; i < _Count; i++)
		{
			if (_List[i] > mobileValue)
			{
				_Directions[i] = !_Directions[i];
			}
		}
	}
}
