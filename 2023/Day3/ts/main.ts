import fs from "fs";

let data = fs.readFileSync("input.txt", "utf-8").split("\n");
for (let i = 0; i < data.length; i++) {
	data[i] = data[i].slice(0, -2);
}
// console.log(data);
function isInt(n: string) {
	let ints = "1234567890";
	if (ints.includes(n)) {
		return true;
	}
	return false;
}
function isSymbol(n: string) {
	if (!isInt(n) && n != ".") {
		return true;
	} else return false;
}
function addToResult(
	valid: boolean,
	char_index_inline: number,
	temp_num_len: number,
	list: Array<string>,
	line_index: number
) {
	if (valid) {
		let string_num: string = "";
		for (let l = 0; l < temp_num_len; l++) {
			string_num += list[line_index][char_index_inline + l];
		}
		console.log(string_num + "-" + temp_num_len);
		return parseInt(string_num);
	} else return 0;
}

function asdf(list: Array<string>) {
	let result: number = 0;
	//first line
	for (let i = 0; i < list[0].length; i++) {
		let temp_num_len: number = 0;
		let valid: boolean = false;
		if (isInt(list[0][i])) {
			temp_num_len = 1;
			if (i < list[0].length - 1 && isInt(list[0][i + 1])) {
				temp_num_len = 2;
				if (i < list[0].length - 2 && isInt(list[0][i + 2])) {
					temp_num_len = 3;
				}
			}
		}
		if (temp_num_len > 0) {
			if (i > 0) {
				if (isSymbol(list[0][i - 1]) || isSymbol(list[1][i - 1])) {
					valid = true;
					result += addToResult(valid, i, temp_num_len, list, 0);
					i += temp_num_len - 1;
				}
			}
			if (isSymbol(list[1][i])) {
				valid = true;
				result += addToResult(valid, i, temp_num_len, list, 0);
				i += temp_num_len - 1;
			}
			if (i > 1) {
				if (
					isSymbol(list[1][i + 1])
					//TODO:check above too in function
				) {
					valid = true;
					result += addToResult(valid, i, temp_num_len, list, 0);
					i += temp_num_len - 1;
				}
			}
			if (i > 2) {
				if (
					(i < list[0].length - 1 && isSymbol(list[0][i + 3])) ||
					isSymbol(list[1][i + 3])
					//TODO:check above diagonally too in function
				) {
				}
				if (
					isSymbol(list[1][i + 2])
					//TODO:check above too in function
				) {
					valid = true;
					result += addToResult(valid, i, temp_num_len, list, 0);
					i += temp_num_len - 1;
				}
			}
		}
	}
	//most
	for (let j = 1; j < list.length - 1; j++) {
		let valid: boolean = false;
		let temp_num_len: number = 0;
		for (let i = 0; i < list[j].length; i++) {
			if (isInt(list[i][i])) {
				temp_num_len = 1;
				if (i < list[i].length - 1 && isInt(list[i][i + 1])) {
					temp_num_len = 2;
					if (i < list[i].length - 2 && isInt(list[i][i + 2])) {
						temp_num_len = 3;
					}
				}
			}
			if (temp_num_len > 0) {
				if (i > 0) {
					if (
						isSymbol(list[j][i - 1]) ||
						isSymbol(list[j + 1][i - 1]) ||
						isSymbol(list[j + 1][i])
					) {
						valid = true;
						result += addToResult(valid, i, temp_num_len, list, j);
						i += temp_num_len - 1;
					}
				}
				if (i > 1) {
					if (
						isSymbol(list[j + 1][i + 1]) ||
						isSymbol(list[j - 1][i + 1])
					) {
						valid = true;
						result += addToResult(valid, i, temp_num_len, list, j);
						i += temp_num_len - 1;
					}
				}
				if (i > 2) {
					if (
						(i < list[j].length - 1 && isSymbol(list[j][i + 3])) ||
						isSymbol(list[j + 1][i + 3]) ||
						isSymbol(list[j - 1][i + 3])
					) {
					}
					if (
						isSymbol(list[j + 1][i + 2]) ||
						isSymbol(list[j - 1][i + 2])
					) {
						valid = true;
						result += addToResult(valid, i, temp_num_len, list, j);
						i += temp_num_len - 1;
					}
				}
			}
		}
	}
	//last line
	for (let k = 0; k < list[list.length - 1].length; k++) {
		let j: number = list.length - 1;
		let valid: boolean = false;
		let temp_num_len: number = 0;
		if (isInt(list[j][k])) {
			temp_num_len = 1;
			if (k < list[j].length - 1 && isInt(list[j][k + 1])) {
				temp_num_len = 2;
				if (k < list[j].length - 2 && isInt(list[j][k + 2])) {
					temp_num_len = 3;
				}
			}
		}
		if (temp_num_len > 0) {
			if (k > 0) {
				if (isSymbol(list[j][k - 1])) {
					valid = true;
					result += addToResult(valid, k, temp_num_len, list, j);
					k += temp_num_len - 1;
				}
			}
			if (k > 1) {
				if (isSymbol(list[j - 1][k + 1])) {
					valid = true;
					result += addToResult(valid, k, temp_num_len, list, j);
					k += temp_num_len - 1;
				}
			}
			if (k > 2) {
				if (
					(k < list[j].length - 1 && isSymbol(list[j][k + 3])) ||
					isSymbol(list[j - 1][k + 3])
				) {
				}
				if (isSymbol(list[j - 1][k + 2])) {
					valid = true;
					result += addToResult(valid, k, temp_num_len, list, j);
					k += temp_num_len - 1;
				}
			}
		}
	}

	console.log(result);
}
function part1(list: Array<string>) {
	let result: number = 0;
	//first line
	let first_line_index: number = 0;
	let i = 0;
	while (i < list[first_line_index].length) {
		let valid: boolean = false;
		let temp_num_len: number = 0;
		if (isInt(list[0][i])) {
			temp_num_len = 1;
			if (i < list[0].length - 1 && isInt(list[0][i + 1])) {
				temp_num_len = 2;
				if (i < list[0].length - 2 && isInt(list[0][i + 2])) {
					temp_num_len = 3;
				}
			}
		}
		if (temp_num_len > 0) {
			if (isSymbol(list[first_line_index + 1][i]) /*TODO:cheeck above*/) {
				valid = true;
			}
			if (
				i > 0 &&
				(isSymbol(list[first_line_index][i - 1]) ||
					isSymbol(
						list[first_line_index + 1][i - 1]
					)) /*TODO:check above diaonal*/
			) {
				valid = true;
			}

			if (
				temp_num_len > 1 &&
				isSymbol(list[first_line_index + 1][i + 1]) /*TODO:check above*/
			) {
				if (
					list[first_line_index].length > i &&
					(isSymbol(list[first_line_index][i + 1]) ||
						isSymbol(
							list[first_line_index + 1][i + 1]
						)) /*TODO:check above diagonal*/
				) {
					valid = true;
				}
				valid = true;
			}
			if (temp_num_len > 2) {
				if (
					list[first_line_index].length - 1 > i &&
					(isSymbol(list[first_line_index][i + 1]) ||
						isSymbol(
							list[first_line_index + 1][i + 1]
						)) /*TODO:Check above diagonal*/
				) {
					valid = true;
				}
			}
		}
		if (valid) {
			let string_num: string = "";
			for (let j = 0; j < temp_num_len; j++) {
				string_num += list[first_line_index][i + j];
			}
			// console.log(string_num + "-" + temp_num_len);
			result += parseInt(string_num);
			i += temp_num_len - 1;
		}
		i++;
	}
	//body
	for (let k = 1; k < list.length - 1; k++) {
		let l: number = 0;
		while (l < list[k].length) {
			let valid: boolean = false;
			let temp_num_len: number = 0;
			if (isInt(list[0][l])) {
				temp_num_len = 1;
				if (l < list[0].length - 1 && isInt(list[0][l + 1])) {
					temp_num_len = 2;
					if (l < list[0].length - 2 && isInt(list[0][l + 2])) {
						temp_num_len = 3;
					}
				}
			}
			if (temp_num_len > 0) {
				if (isSymbol(list[k + 1][l]) || isSymbol(list[k - 1][l])) {
					valid = true;
				}
				if (
					l > 0 &&
					(isSymbol(list[k][l - 1]) ||
						isSymbol(list[k + 1][l - 1]) ||
						isSymbol(list[k - 1][l - 1]))
				) {
					valid = true;
				}
				if (
					temp_num_len > 1 &&
					(isSymbol(list[k + 1][l + 1]) ||
						isSymbol(list[k - 1][l + 1]))
				) {
					if (
						list[k].length > l &&
						(isSymbol(list[k][l + 1]) ||
							isSymbol(list[k + 1][l + 1]) ||
							isSymbol(list[k - 1][l + 1]))
					) {
						valid = true;
					}
					valid = true;
				}
				if (temp_num_len > 2) {
					if (
						list[k].length - 1 > l &&
						(isSymbol(list[k][l + 1]) ||
							isSymbol(list[k + 1][l + 1]) ||
							isSymbol(list[k - 1][l + 1]))
					) {
						valid = true;
					}
				}
			}
			if (valid) {
				let string_num: string = "";
				for (let j = 0; j < temp_num_len; j++) {
					string_num += list[k][l + j];
				}
				console.log(string_num + "-" + l);
				result += parseInt(string_num);
				l += temp_num_len - 1;
			}
			l++;
		}
	}
	//last line
	let m: number = 0;
	let last_line_index = list.length - 1;
	while (m < list[last_line_index].length) {
		let valid: boolean = false;
		let temp_num_len: number = 0;
		if (isInt(list[0][m])) {
			temp_num_len = 1;
			if (m < list[0].length - 1 && isInt(list[0][m + 1])) {
				temp_num_len = 2;
				if (m < list[0].length - 2 && isInt(list[0][m + 2])) {
					temp_num_len = 3;
				}
			}
		}
		if (temp_num_len > 0) {
			if (
				//TODO:remove check beloves from down here
				isSymbol(list[last_line_index - 1][m])
			) {
				valid = true;
			}
			if (
				m > 0 &&
				(isSymbol(list[last_line_index][m - 1]) ||
					isSymbol(list[last_line_index - 1][m - 1]))
			) {
				valid = true;
			}
			if (
				temp_num_len > 1 &&
				isSymbol(list[last_line_index - 1][m + 1])
			) {
				if (
					list[last_line_index].length > m &&
					(isSymbol(list[last_line_index][m + 1]) ||
						isSymbol(list[last_line_index - 1][m + 1]))
				) {
					valid = true;
				}
				valid = true;
			}
			if (temp_num_len > 2) {
				if (
					list[last_line_index].length - 1 > m &&
					(isSymbol(list[last_line_index][m + 1]) ||
						isSymbol(list[last_line_index - 1][m + 1]))
				) {
					valid = true;
				}
			}
		}
		if (valid) {
			let string_num: string = "";
			for (let j = 0; j < temp_num_len; j++) {
				string_num += list[last_line_index][m + j];
			}
			// console.log(string_num + "-" + temp_num_len);
			result += parseInt(string_num);
			m += temp_num_len - 1;
		}
		m++;
	}
	console.log(result);
}
function part2(list: Array<string>) {}

part1(data);
// part2(data);
