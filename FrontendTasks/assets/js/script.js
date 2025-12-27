function getNumbers() {
    const num1 = parseFloat(document.getElementById('number1').value);
    const num2 = parseFloat(document.getElementById('number2').value);
    
    if (isNaN(num1) || isNaN(num2)) {
        return null;
    }
    
    return { num1, num2 };
}

function showResult(operation, result) {
    const resultDiv = document.getElementById('result');
    resultDiv.innerHTML = `<span class="result-text">${operation}:</span><span class="result-value">${result}</span>`;
}

function showError(message) {
    const resultDiv = document.getElementById('result');
    resultDiv.innerHTML = `<span class="result-text" style="color: #f44336;">${message}</span>`;
}

function toplama() {
    const numbers = getNumbers();
    if (!numbers) {
        showError('Zəhmət olmasa hər iki rəqəmi daxil edin!');
        return;
    }
    
    const result = numbers.num1 + numbers.num2;
    showResult('Toplama', result);
}

function cixma() {
    const numbers = getNumbers();
    if (!numbers) {
        showError('Zəhmət olmasa hər iki rəqəmi daxil edin!');
        return;
    }
    
    const result = numbers.num1 - numbers.num2;
    showResult('Çıxma', result);
}

function vurma() {
    const numbers = getNumbers();
    if (!numbers) {
        showError('Zəhmət olmasa hər iki rəqəmi daxil edin!');
        return;
    }
    
    const result = numbers.num1 * numbers.num2;
    showResult('Vurma', result);
}

function bolme() {
    const numbers = getNumbers();
    if (!numbers) {
        showError('Zəhmət olmasa hər iki rəqəmi daxil edin!');
        return;
    }
    
    if (numbers.num2 === 0) {
        showError('Sıfıra bölmək mümkün deyil!');
        return;
    }
    
    const result = numbers.num1 / numbers.num2;
    showResult('Bölmə', result.toFixed(2));
}