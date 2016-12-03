using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeatherApp
{
    class ZipCodeBehavior : Behavior<Entry>
    {
        /// <summary>
        /// 正規表現
        /// </summary>
        private Regex _reg;

        public int MaxLength { get; set; } = 100;

        /// <summary>
        /// 正規表現パターン
        /// </summary>
        public string RegexPattern { get { return _reg?.ToString(); } set { _reg = new Regex(value); } }

        /// <summary>
        /// Attached
        /// </summary>
        /// <param name="c"></param>
        protected override void OnAttachedTo(Entry c)
        {
            c.TextChanged += TextChanged;
        }

        /// <summary>
        /// Detaching
        /// </summary>
        /// <param name="c"></param>
        protected override void OnDetachingFrom(Entry c)
        {
            c.TextChanged -= TextChanged;
        }

        /// <summary>
        /// 入力テキスト変更時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue)) { return; }

            // 入力制限文字数を越えていたら帰る
            if (MaxLength < e.NewTextValue?.Length)
            {
                ((Entry)sender).Text = e.OldTextValue;
                return;
            }

            // 正規表現にマッチする場合 OK
            if ((_reg?.IsMatch(e.NewTextValue ?? string.Empty)).GetValueOrDefault()) WeatherPage.RegOK = true;
        }
    }
}
