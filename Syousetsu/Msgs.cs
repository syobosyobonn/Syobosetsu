using System.Windows.Forms;

namespace Syobosetsu
{
    internal class Msgs
    {
        public static void MsgDialog(int mode) 
        {
            //1x→info 
            //2x→error
            //3x→Warn

            //10→ファイル群が保存されました。

            //20→エラーにより、ファイルのオープンに失敗しました。
            //21→指定された最大文字数をテキストが超えています。
            //22→指定された最大列数をテキストが超えています。
            //23→指定された最大行数をテキストが超えています。
            //24→この項目は管理者権限が必要です。

            //30→変更内容は保存されませんでした。
            //31→ファイル群は保存されませんでした。
            //32→このファイルは最大文字数制限を違反していたため、文字数制限を一時的に解除しました。
            //33→このファイルは最大列数制限を違反していたため、列数制限を一時的に解除しました。
            //34→このファイルは最大行数制限を違反していたため、行数制限を一時的に解除しました。
            //35→読み込まれたファイルはテキストファイルではありません。\nアプリの動作が不安定になる可能性があります。


            switch (mode)
            {              
                case 10:
                    MessageBox.Show("ファイル群が保存されました。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case 20:
                    MessageBox.Show($"エラーにより、ファイルのオープンに失敗しました。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 21:
                    MessageBox.Show("指定された最大文字数をテキストが超えています。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 22:
                    MessageBox.Show("指定された最大列数をテキストが超えています。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 23:
                    MessageBox.Show("指定された最大行数をテキストが超えています。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 24:
                    MessageBox.Show("この項目は管理者権限が必要です。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 30:
                    MessageBox.Show("変更内容は保存されませんでした。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case 31:
                    MessageBox.Show("ファイル群は保存されませんでした。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case 32:
                    MessageBox.Show("このファイルは最大文字数制限を違反していたため\n文字数制限を一時的に解除しました。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case 33:
                    MessageBox.Show("このファイルは最大列数制限を違反していたため\n列数制限を一時的に解除しました。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case 34:
                    MessageBox.Show("このファイルは最大行数制限を違反していたため\n行数制限を一時的に解除しました。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case 35:
                    MessageBox.Show("読み込まれたファイルはテキストファイルではありません。\nアプリの動作が不安定になる可能性があります。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
    }
}
