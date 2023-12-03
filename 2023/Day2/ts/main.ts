import fs from "fs";

let input = fs.readFileSync("input.txt", "utf-8").split("\n");
// console.log(data);
let games: Array<Array<{ [key: string]: number }>> = new Array<
	Array<{ [key: string]: number }>
>();
for (let i = 0; i < input.length; i++) {
	let game: Array<{ [key: string]: number }> = new Array<{
		[key: string]: number;
	}>();
	let reveals = input[i].trim().split(";");

	for (let l = 0; l < reveals.length; l++) {
		let curr_rev: Array<string> = reveals[l].split(",");

		let obj_template: { [key: string]: number } = { r: 0, b: 0, g: 0 };
		for (let j = 0; j < curr_rev.length; j++) {
			let color_num: Array<string> = curr_rev[j].split(" ");
			if (color_num[0] == "Game") {
				color_num.splice(1, 1);
				color_num.splice(0, 1);
			} else {
				color_num.splice(0, 1);
			}
			obj_template[color_num[1][0]] = parseInt(color_num[0]);
		}
		game.push(obj_template);
	}
	games.push(game);
}
function part1(list: Array<Array<{ [key: string]: number }>>) {
	let result: number = 0;
	for (let i = 0; i < list.length; i++) {
		let possible: boolean = true;
		for (let j = 0; j < games[i].length; j++) {
			if (
				games[i][j].r > 12 ||
				games[i][j].g > 13 ||
				games[i][j].b > 14
			) {
				possible = false;
				break;
			}
		}
		console.log(games[i], possible);

		if (possible) {
			result += i + 1;
		}
	}
	console.log(result);
}
// console.log(games);

function part2(list: Array<Array<{ [key: string]: number }>>) {
	let result: number = 0;
	for (let i = 0; i < list.length; i++) {
		let obj_template: { [key: string]: number } = { r: 0, b: 0, g: 0 };
		for (let j = 0; j < list[i].length; j++) {
			if (list[i][j].r > obj_template.r) {
				obj_template.r = list[i][j].r;
			}
			if (list[i][j].b > obj_template.b) {
				obj_template.b = list[i][j].b;
			}
			if (list[i][j].g > obj_template.g) {
				obj_template.g = list[i][j].g;
			}
		}
		result += obj_template.r * obj_template.b * obj_template.g;
	}
	console.log(result);
}

// part1(games);
part2(games);
