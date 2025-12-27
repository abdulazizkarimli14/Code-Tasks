document.addEventListener('DOMContentLoaded', function() {
    initializeEventListeners();
});


function initializeEventListeners() {
    const input1 = document.getElementById('number1');
    const input2 = document.getElementById('number2');
    
    
    input1.addEventListener('input', handleInputChange);
    input2.addEventListener('input', handleInputChange);
    
    
    input1.addEventListener('keypress', handleKeyPress);
    input2.addEventListener('keypress', handleKeyPress);
    
    
    input1.addEventListener('focus', handleFocus);
    input2.addEventListener('focus', handleFocus);
    
    
    input1.addEventListener('blur', handleBlur);
    input2.addEventListener('blur', handleBlur);
}


function handleInputChange(event) {
    const value = event.target.value;
    if (value !== '') {
        event.target.style.borderColor = '#4CAF50';
    } else {
        event.target.style.borderColor = '#ddd';
    }
}


function handleKeyPress(event) {
    
    if (event.key === 'Enter') {
        event.preventDefault();
        toplama();
    }
    
    else if (event.key === '+') {
        event.preventDefault();
        toplama();
    }
   
    else if (event.key === '-' && event.target.value === '') {
        
        return true;
    }
    else if (event.key === '-' && event.target.value !== '') {
        event.preventDefault();
        cixma();
    }
    
    else if (event.key === '*') {
        event.preventDefault();
        vurma();
    }
    
    else if (event.key === '/') {
        event.preventDefault();
        bolme();
    }
}


function handleFocus(event) {
    event.target.style.borderColor = '#2196F3';
    event.target.style.boxShadow = '0 0 5px rgba(33, 150, 243, 0.3)';
}


function handleBlur(event) {
    if (event.target.value !== '') {
        event.target.style.borderColor = '#4CAF50';
    } else {
        event.target.style.borderColor = '#ddd';
    }
    event.target.style.boxShadow = 'none';
}


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
    resultDiv.classList.add('show-result');
}


function showError(message) {
    const resultDiv = document.getElementById('result');
    resultDiv.innerHTML = `<span class="result-text" style="color: #f44336;">${message}</span>`;
    resultDiv.classList.add('show-result');
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


function clearAll() {
    document.getElementById('number1').value = '';
    document.getElementById('number2').value = '';
    document.getElementById('result').innerHTML = '<span class="placeholder">nəticəni buranı yazdırın</span>';
    document.getElementById('number1').style.borderColor = '#ddd';
    document.getElementById('number2').style.borderColor = '#ddd';
}