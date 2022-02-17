
async function triggerInputElement(inputElement, filter, multiple, openFolder) {
  inputElement.accept = filter;
  inputElement.multiple = multiple;
  inputElement.webkitdirectory = openFolder;
  await inputElement.click();
}

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
