using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AntiqueEye.Models;
using AntiqueEye.Models.Cryptography;
using Prism.Mvvm;
using Reactive.Bindings;

namespace AntiqueEye.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IBlockModule _blockModule;


        private ObservableCollection<Block> BlockList { get; set; }

        public AsyncReactiveCommand<string> AuthCommand { get; set; }

        public ReactiveProperty<bool> IsUnlocked { get; set; }

        public ReactiveProperty<string> ErrorMessage { get; set; }

        public ReactiveProperty<bool> IsEditMode { get; set; }

        private string Master { get; set; }


        public MainWindowViewModel(IBlockModule blockModule)
        {
            _blockModule = blockModule;
            ErrorMessage = new ReactiveProperty<string>("");
            AuthCommand = new();
            IsUnlocked = new ReactiveProperty<bool>(false);
            IsEditMode = new ReactiveProperty<bool>(false);

            AuthCommand.Subscribe(async master =>
            {
                Master = master;
                try
                {
                    var list = await _blockModule.GetBlocksAsync(Master);
                    BlockList = new ObservableCollection<Block>(list ?? new List<Block>());
                    IsUnlocked.Value = true;
                }
                catch (FileNotFoundException)
                {
                    BlockList = new ObservableCollection<Block>();
                    IsUnlocked.Value = true;
                }
                catch (CryptographicException)
                {
                    IsUnlocked.Value = false;
                    ErrorMessage.Value = "パスワードが違います。";
                }
                catch
                {
                    IsUnlocked.Value = false;
                    ErrorMessage.Value = "不明なエラーです。";
                }
            });
        }
    }
}
