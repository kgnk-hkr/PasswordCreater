using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_PasswordCreator
{
	class ViewModel : INotifyPropertyChanged //INotifyPropertyChangedインターフェイスの実装：プロパティの値が変更になったことをVIEWに通知する
	{
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
		{
			if (PropertyChanged == null) return;
			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
