# bdv-pixel-to-json

Script to quickly get a mapped pixel value JSON.

---

### Basic Usage

1. Configure your input and output file path in the `config.json` file.
2. Run `dotnet run` in this repository extracted directory.
3. Look for your json file in the configured path.

--- 

### Example of usage on config.json 

```json
{
    "path": "/home/bdv/Images/tile.png",
    "outFilePath": "/home/bdv/Images/"
}
```

### Output JSON format

This tool ouputs a JSON file with the format:
```javascript
    matrix[imageWidth][imageHeight] = {R: byte, G: byte, B: byte, A: byte}
```
