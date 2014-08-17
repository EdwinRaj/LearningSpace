using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Reactive.Linq;
using System.Timers;
using System.Reactive.Subjects;

namespace Citi.CodeTest.Server
{
    [Export(typeof(IStockProvider))]
	internal class StockProvider : IStockProvider
	{
		private static readonly List<string> SymbolNames = new List<string> {"MSFT", "IBM", "APPL"};
		private readonly Random _random = new Random();
		private readonly Dictionary<string, StockItem> _symbols = new Dictionary<string, StockItem>();
		private readonly Timer _timer;
        private readonly Subject<IStockItem> _subject = new Subject<IStockItem>();

		public StockProvider()
		{
			// Populate with symbols
			SymbolNames.ForEach(x => _symbols.Add(x, CreateTick(x)));

			// Simple timer for triggering ticks
			_timer = new Timer {Interval = 500};
			_timer.Elapsed += TimerElapsed;
			_timer.Start();
            _timer.AutoReset = false;
		}

		#region IStockProvider Members

		/// <summary>
		/// Returns as list of available unique stock symbols
		/// </summary>
		public IEnumerable<string> StockSymbols
		{
			get { return _symbols.Keys; }
		}

		/// <summary>
		/// Subcribes to price updates for a specific given symbol.
		/// </summary>
		/// <param name="symbol">The symbol name</param>
		/// <returns>Observable subscription of IStockItems</returns>
		public IObservable<IStockItem> Subscribe(string symbol)
		{
            return (from x in _subject where x.Name == symbol select x);
		}

		#endregion

        #region IObservable<IStockItem> Members

        public IDisposable Subscribe(IObserver<IStockItem> observer)
        {
            return (from x in _subject select x).Subscribe();
        }

        #endregion

        private void TimerElapsed(object sender, ElapsedEventArgs e)
		{
			var keys = new List<string>(_symbols.Keys);
			foreach (string symbol in keys)
			{
				UpdateTick(symbol);
			}
            _timer.Start();
		}

		private StockItem CreateTick(string symbol)
		{
			double initialBid = 90 + (_random.NextDouble()*20.0);
			double initialAsk = initialBid + (_random.NextDouble() + 0.5);
			return new StockItem(symbol, initialBid, initialAsk);
		}

		private void UpdateTick(string symbol)
		{
			StockItem oldSi = _symbols[symbol];
			double initialBid = Math.Max(0.1, oldSi.Bid + ((_random.NextDouble()*2.0) - 1));
			double initialAsk = initialBid + (_random.NextDouble() + 0.5);
			var newItem = new StockItem(symbol, initialBid, initialAsk);
			_symbols[symbol] = newItem;
            _subject.OnNext(newItem);
		}
    }
}