using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_PasswordCreator
{
	public class DelegateCommand : ICommand //Commandプロパティを設定するもの。
	{
		//引数の設定
		private Action execute;
		private Func<bool> canExecute;
		public DelegateCommand(Action execute,Func<bool> canExecute)
		{
			this.execute = execute;
			this.canExecute = canExecute;
		}

		//Actionの引数だけコンストラクターを作成する
		public DelegateCommand(Action execute) : this(execute, () => true) { } //コンストラクターの作成
		//実行に影響するような変更があった時に発生する部分
		//WPFのおまじない的な部分
		public event EventHandler CanExecuteChanged 
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}


		//public event EventHandler CanExecuteChanged;

		//以下二つのメソッドは引数のデリゲートに処理をゆだねている
		public bool CanExecute(object parameter) //実行条件を指定する
		{
			//throw new NotImplementedException();
			return canExecute();
		}

		public void Execute(object parameter) //コマンドの実行時に呼び出される
		{
			//throw new NotImplementedException();
			execute();
		}
	}
}
