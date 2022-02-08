
// https://stackoverflow.com/questions/4628544/how-to-detect-when-cancel-is-clicked-on-file-input

// https://codepen.io/matuzo/pen/KOdpmq?editors=1111
// https://caniuse.com/?search=webkitdirectory

async function ShowInputDialog(id) {
    await document.querySelector('input#' + id).click();
}


// https://web.dev/file-system-access/
// https://www.thinktecture.com/en/pwa/making-of-paint-js-file-access/


// https://developer.mozilla.org/en-US/docs/Web/API/Window/showOpenFilePicker

const pickerOpts = {
    types: [
      {
        description: 'Supported files',
        accept: {
          'image/*': ['.png', '.gif', '.jpeg', '.jpg']
        }
      },
    ],
    excludeAcceptAllOption: true,
    multiple: false
  };

// create a reference for our file handle
let fileHandle;

async function getFile() {
  // open file picker, destructure the one element returned array
  [fileHandle] = await window.showOpenFilePicker(pickerOpts);

  // run code with our fileHandle
  
}



// https://developer.mozilla.org/en-US/docs/Web/API/window/showSaveFilePicker

function getNewFileHandle() {
    const opts = {
      types: [{
        description: 'Text file',
        accept: {'text/plain': ['.txt']},
      }],
    };
    return window.showSaveFilePicker(opts);
  }


  // https://developer.mozilla.org/en-US/docs/Web/API/window/showDirectoryPicker
