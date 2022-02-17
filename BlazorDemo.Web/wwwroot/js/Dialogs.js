//
// Open File
//

async function ShowOpenFileDialog(inputElement, filter, multiple, openFolder) {
  inputElement.accept = filter;
  inputElement.multiple = multiple;
  inputElement.webkitdirectory = openFolder;
  await inputElement.click();
}

//
// Save File
//

async function downloadFileFromStream(fileName, contentStreamReference) {
  const arrayBuffer = await contentStreamReference.arrayBuffer();
  const blob = new Blob([arrayBuffer]);
  const url = URL.createObjectURL(blob);
  triggerFileDownload(fileName, url);
  URL.revokeObjectURL(url);
}

function triggerFileDownload(fileName, url) {
  const anchorElement = document.createElement('a');
  anchorElement.style = "display: none";
  anchorElement.href = url;
  anchorElement.download = fileName ?? '';
  anchorElement.click();
  anchorElement.remove();
}

//
// File Pickers
//

// https://wicg.github.io/file-system-access/
// https://web.dev/file-system-access/
// https://w3c.github.io/FileAPI/#dfn-file
// https://developer.mozilla.org/en-US/docs/Web/API/Window/showOpenFilePicker

function GetPropertyValue(obj, property) {
  return obj[property];
}

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
  const fileHandle = fileHandles[0];
  return fileHandle;
  // return fileHandle.Name;
  // const file = await fileHandles[0].getFile();
  // return file;
}

// USAGE:
// var fileHandle = await ShowOpenFilePicker();
// var file = await fileHandle.getFile();
// var stream = await file.stream();
// var reader = await stream.getReader();
// var text = await file.text();
// var arrayBuffer = await file.arrayBuffer();

// https://developer.mozilla.org/en-US/docs/Web/API/window/showSaveFilePicker

function ShowSaveFilePicker() {
    const opts = {
      types: [{
        description: 'Text file',
        accept: {'text/plain': ['.txt']},
      }],
    };
    const fileHandle = window.showSaveFilePicker(opts);
    return fileHandle;
  }

// https://developer.mozilla.org/en-US/docs/Web/API/window/showDirectoryPicker

async function ShowDirectoryPicker() {
  const dirHandle = await window.showDirectoryPicker();
  return dirHandle;
}


// const dirHandle = await window.showDirectoryPicker();
// var entries = await dirHandle.entries();
