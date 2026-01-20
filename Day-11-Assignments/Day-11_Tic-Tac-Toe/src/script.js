const boxes = document.querySelectorAll(".box");
const turnBoxes = document.querySelectorAll(".turn-box");

const playAgainBtn = document.getElementById("play-again");
const resetBtn = document.getElementById("reset-game");
const resultText = document.getElementById("results");

let currentTurn = "X";
let gameOver = false;

// Initial state
playAgainBtn.style.display = "none";
resetBtn.disabled = false;

// Click handling
boxes.forEach(box => {
    box.addEventListener("click", () => {
        if (!gameOver && box.innerHTML === "") {
            box.innerHTML = currentTurn;
            checkWin();
            checkDraw();
            if (!gameOver) switchTurn();
        }
    });
});

// Switch player turn
function switchTurn() {
    if (currentTurn === "X") {
        currentTurn = "O";
        turnBoxes[0].classList.remove("active");
        turnBoxes[1].classList.add("active");
    } else {
        currentTurn = "X";
        turnBoxes[1].classList.remove("active");
        turnBoxes[0].classList.add("active");
    }
}

// Win check
function checkWin() {
    const patterns = [
        [0,1,2],[3,4,5],[6,7,8],
        [0,3,6],[1,4,7],[2,5,8],
        [0,4,8],[2,4,6]
    ];

    patterns.forEach(p => {
        const [a,b,c] = p;
        if (boxes[a].innerHTML && boxes[a].innerHTML === boxes[b].innerHTML && boxes[a].innerHTML === boxes[c].innerHTML) {
            gameOver = true;
            resultText.innerText = currentTurn + " Wins!";
            playAgainBtn.style.display = "block";
            resetBtn.disabled = true;

            boxes[a].style.background=boxes[b].style.background=boxes[c].style.background = "#00ff95";
        }
    });
}

// Draw check
function checkDraw() {
    if (!gameOver) {
        let filled = true;
        boxes.forEach(b => {
            if (b.innerHTML === "") filled = false;
        });
        if (filled) {
            gameOver = true;
            resultText.innerText = "Draw!";
            playAgainBtn.style.display = "block";
            resetBtn.disabled = true;
        }
    }
}

// Reset Game (anytime during play)
resetBtn.addEventListener("click", () => {
    boxes.forEach(b => {
        b.innerHTML = "";
        b.style.background = "";
    });

    gameOver = false;
    currentTurn = "X";

    turnBoxes[1].classList.remove("active");
    turnBoxes[0].classList.add("active");

    resultText.innerText = "";
    playAgainBtn.style.display = "none";
    resetBtn.disabled = false;
});

// Play Again (after win/draw)
playAgainBtn.addEventListener("click", () => {
    boxes.forEach(b => {
        b.innerHTML = "";
        b.style.background = "";
    });

    gameOver = false;
    currentTurn = "X";

    turnBoxes[1].classList.remove("active");
    turnBoxes[0].classList.add("active");

    resultText.innerText = "";
    playAgainBtn.style.display = "none";
    resetBtn.disabled = false;
});
