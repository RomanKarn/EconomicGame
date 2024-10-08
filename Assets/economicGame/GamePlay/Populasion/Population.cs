public class Population : ITikeProsses
{
	private int _collPeole;
	private int _feeling;
	private ProvidePopulation _providePopulation;

	public int CollPepole { get => _collPeole; }
	public int Feeling { get => _feeling; }

	private float prosentAdd = 0.15f;
	private float prosentRedus = 0.05f;

	public Population(ProvidePopulation providePopulation)
	{
		_collPeole = 10;
		_providePopulation = providePopulation;
	}

	public void PossesInTike()
	{
		IncreasePopulashion();
	}

	private void IncreasePopulashion()
	{
		CalculateFeeelingPopulashion();
		float addPopul = (_collPeole * prosentAdd * (_feeling / 100f) * (_providePopulation.MaxPopulationInTile - _collPeole) / _providePopulation.MaxPopulationInTile);
		float redusPopul = (_collPeole * prosentRedus * (1f - _feeling / 100f) * (1 - (_providePopulation.MaxPopulationInTile - _collPeole) / _providePopulation.MaxPopulationInTile));
		if (_providePopulation.MaxPopulationInTile > _collPeole && addPopul > redusPopul)
		{
			_collPeole += (int)(addPopul - redusPopul);
		}
		else if (addPopul < redusPopul)
		{
			_collPeole += (int)(addPopul - redusPopul);
		}
	}

	private void CalculateFeeelingPopulashion()
	{
		int hospFeeling = (_providePopulation.HospitalProvide / _collPeole) >= 1 ? 100 : (_providePopulation.HospitalProvide / _collPeole) * 100;
		int securFeeling = (_providePopulation.SecuretyProvide / _collPeole) >= 1 ? 100 : (_providePopulation.SecuretyProvide / _collPeole) * 100;
		int compfFeeling = (_providePopulation.CompfortProvide / _collPeole) >= 1 ? 100 : (_providePopulation.CompfortProvide / _collPeole) * 100;
		_feeling = (hospFeeling + securFeeling + compfFeeling) / 3;
	}

}







