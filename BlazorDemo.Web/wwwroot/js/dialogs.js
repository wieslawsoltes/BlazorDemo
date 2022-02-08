

async function ShowInputDialog(id, filter, multiple, openFolder) {
    var input = document.querySelector('input#' + id);
    input.accept = filter;
    input.multiple = multiple;
    input.webkitdirectory = openFolder;
    await input.click();
}

// https://web.dev/file-system-access/

// https://developer.mozilla.org/en-US/docs/Web/API/Window/showOpenFilePicker

async function ShowOpenFilePicker() {

  const opts = {
    types: [
      {
        description: 'Text file',
        accept: {'text/plain': ['.txt']},
      },
    ],
    excludeAcceptAllOption: true,
    multiple: false
  };

  const fileHandles = await window.showOpenFilePicker(opts);
  const file = await fileHandles[0].getFile();

  return file.stream();
}

// https://developer.mozilla.org/en-US/docs/Web/API/window/showSaveFilePicker

function ShowSaveFilePicker() {
    const opts = {
      types: [{
        description: 'Text file',
        accept: {'text/plain': ['.txt']},
      }],
    };
    return window.showSaveFilePicker(opts);
  }

// https://developer.mozilla.org/en-US/docs/Web/API/window/showDirectoryPicker

async function ShowDirectoryPicker() {
  const dirHandle = await window.showDirectoryPicker();
  return dirHandle;
}
