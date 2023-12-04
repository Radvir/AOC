const fs = require("fs");

let data = fs.readFileSync("input.txt", "utf-8").split("\n");

class card{
	win_nums;
	own_nums;
}