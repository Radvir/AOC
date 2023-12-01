const fs = require("fs");

let data = fs.readFileSync('input.txt', 'utf-8').split("\n");
// console.log(data);
function isInt(n) {
    let ints = "1234567890";
    if (ints.includes(n)) { return true; }
    return false;
}
function part1(list) {
    let result = 0;
    for (let i = 0; i < list.length; i++) {
        let num = "";
        for (let j = 0; j < list[i].length; j++) {
            if (isInt(list[i][j])) {
                num += list[i][j];
                break;
            }
        }
        for (let k = list[i].length - 1; k >= 0; k--) {
            if (isInt(list[i][k])) {
                num += list[i][k];
                break;
            }
        }
        console.log(num);
        result += parseInt(num);
    }
    console.log(result)
}

function part2(list) {
    let result = 0;
    let nums = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];
    for (let i = 0; i < list.length; i++) {
        let num = "";
        let first_num = "";
        let first_num_index = -1;
        let first_string_index = -1;
        let first_string_num = "";

        for (let j = 0; j < list[i].length; j++) {
            if (isInt(list[i][j])) {
                first_num_index = j;
                break;
            }
        }
            for (let l = 0; l < nums.length; l++) {
                if (list[i].includes(nums[l])) {
                    if (-1== first_string_index || list[i].indexOf(nums[l]) < first_string_index) {
                        first_string_index = list[i].indexOf(nums[l]);
                        first_string_num = l+1;
                    }
                }
            }
        

        if (first_num_index != -1 && first_string_index != -1&& first_num_index < first_string_index) {
            first_num = list[i][first_num_index];
        } else {
            first_num = first_string_num;
        }

        let second_num = "";
        let second_num_index = -1;
        let second_string_index = -1;
        let second_string_num = "";
        for (let j = list[i].length - 1; j >= 0; j--) {
            if (isInt(list[i][j])) {
                second_num_index = j;
                break;
            }
        }
            for (let l = list[i].length - 1; l >= 0; l--) {
                if (list[i].includes(nums[l])) {
                    if (list[i].indexOf(nums[l]) > second_string_index || -1 == second_string_index) {
                        second_string_index = list[i].indexOf(nums[l]);
                        second_string_num = l+1;
                    }
                }
            }
        
        if (second_string_index != -1 && second_num_index != -1 &&second_num_index > second_string_index) {
            second_num = list[i][second_num_index];
        } else {
            second_num = second_string_num;
        }
        console.log(`${first_num}${second_num}`);
        result += parseInt(`${first_num}${second_num}`);
    }
    console.log(result)
}

// part1(data);
part2(data);