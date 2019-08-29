using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordCreator22;
using System.Windows.Forms;

namespace WPF_PasswordCreator
{
    class MainWindowVM : ViewModel
    {
		private ILetterFactory factory; //ILetterFactoryの設定
		private bool isNonMark;
		public bool IsNonMark //記号なし
		{
			get { return isNonMark; }
			set
			{
				isNonMark = value;
				if (isNonMark)
				//{
					factory = new NonMarkLetterFactory();
				//}
				//else
				//{
				//	factory = new AllLetterFactory();
				//}
			}
		}
		private bool isAll;
		public bool IsAll //すべての時
		{
			get { return isAll; }
			set
			{
				isAll = value;
				if (isAll) factory = new AllLetterFactory();
			}
		}
		private bool isMark2;
		public bool IsMark2 //記号が二つの時
		{
			get { return isMark2; }
			set
			{
				isMark2 = value;
				if (isMark2) factory = new Mark2LetterFactory();
			}
		}

		//生成パスワードの文字数指定部分
		private int numOfLetters;
		public int NumOfLetters //文字数指定の枠のためのプロパティ
		{
			get { return numOfLetters; }
			set { numOfLetters = value; } //下で定義してるNumofLetterを見に行ってる
		}

		//パスワード生成・表示部分
		private string createdPassword;
		public string CreatedPassword
		{
			get { return createdPassword; }
			set { createdPassword = value; Clipboard.SetText(createdPassword); OnPropertyChanged(); } //生成したパスワードを表示し、クリップボードにコピーする
		}

		public DelegateCommand MakePassword { get; private set; } //プロパティの作成（デリゲート
		//パスワードを生成するメソッド
		private void MakePasswordExecute()
		{
			Random random = new Random();
			var generator = new PasswordGenerator(random);
			CreatedPassword = generator.MakePassword(NumOfLetters, factory);
		}

		//パスワード生成するための条件
		private bool CanMakePasswordExecute()
		{
			return NumOfLetters > 10; //パスワードの指定文字数が10文字以上であること
		}

		public MainWindowVM()
		{
			NumOfLetters = 20; //初期値
			//IsNonMark = true;
			//CreatedPassword = "This is WPF Application";
			IsAll = true; //起動時に『記号あり』にチェックが入るように
			//実行処理をするものと実行条件の指定
			MakePassword = new DelegateCommand(MakePasswordExecute, CanMakePasswordExecute);
		}
    }
}
