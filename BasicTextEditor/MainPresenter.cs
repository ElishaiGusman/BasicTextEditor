using System;
using BasicTextEditor.BL;

namespace BasicTextEditor
{
    class MainPresenter
    {
        private readonly IMainForm _view;
        private readonly IMessageService _messageService;
        private readonly IFileManager _fileManager;

        private string _currentFilePath;

        public MainPresenter(IMainForm view, IMessageService messageService, IFileManager fileManager)
        {
            _view = view;
            _messageService = messageService;
            _fileManager = fileManager;

            _view.SetSymbolCount(0);

            //Events
            _view.ContentChanged += _view_ContentChanged;
            _view.OpenFileClick += _view_OpenFileClick;
            _view.SaveFileClick += _view_SaveFileClick;
        }


        private void _view_ContentChanged(object sender, System.EventArgs e)
        {
            string content = _view.Content;

            int count = _fileManager.GetSymbolCount(content);

            _view.SetSymbolCount(count);
        }

        private void _view_OpenFileClick(object sender, System.EventArgs e)
        {
            try
            {
                string filePath = _view.FilePath;

                bool isExist = _fileManager.IsExist(filePath);

                if(!isExist)
                {
                    _messageService.ShowExclamation("The selected file does not exist.");
                    return;
                }

                _currentFilePath = filePath;

                string content = _fileManager.GetContent(filePath);
                int count = _fileManager.GetSymbolCount(content);

                _view.Content = content;
                _view.SetSymbolCount(count);
            }
            catch(Exception exception)
            {
                _messageService.ShowError(exception.Message);
            }
        }

        private void _view_SaveFileClick(object sender, EventArgs e)
        {
            try
            {
                string content = _view.Content;

                _fileManager.SaveContent(content, _currentFilePath);

                _messageService.ShowMessage("The file was saved successfully.");
            }
            catch(Exception exception)
            {
                _messageService.ShowError(exception.Message);
            }
        }
    }
}
