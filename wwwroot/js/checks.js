function validate(){
    var flag = true;
    resetErrorBoxes();
    dropHighlighting();

    if (!checkMileageCompatibility(document.getElementById('mileage').value,
        document.getElementById('state').value)){
        flag = false;
        document.getElementById('mileage-error').innerHTML +=
            `
            <p>У нового автомобиля пробег должен быть равен 0</p>
            
            `;
        document.getElementById('mileage').style.color = 'red';
    }
    if (!checkConsumptionCompatibility(document.getElementById('engine').value,
        document.getElementById('consumption').value)){
        flag = false;
        document.getElementById('consumption-error').innerHTML +=
            `
            <p>Расход топлива не может быть меньше 4 л / 100 км у бензиновых и 
            3 л / 100 км у дизельных двигателей</p>
            
            `;
        document.getElementById('consumption').style.color = 'red';
    }
    if (!checkTransmissionCompatibility(document.getElementById('transmission').value,
        document.getElementById('transmissionlevels').value)){
        flag = false;
        document.getElementById('transmissionlevels-error').innerHTML +=
            `
            <p>У автомобилей с МКПП должно быть хотя бы 4 передачи</p>
            
            `;
        document.getElementById('transmissionlevels').style.color = 'red';
    }
    if (!checkYear(document.getElementById('year').value)){
        flag = false;
        document.getElementById('year-error').innerHTML +=
            `
            <p>Год производства автомобиля не может быть больше нынешнего</p>
            
            `;
        document.getElementById('year').style.color = 'red';
    }
    if (!checkYearCompatability(document.getElementById('state').value,
        document.getElementById('year').value)){
        flag = false;
        document.getElementById('year-error').innerHTML +=
            `
            <p>Автомобиль может считаться новым только 2 года после производства</p>
            
            `;
        document.getElementById('year').style.color = 'red';
    }


    if (flag){
        window.alert('Запись успешно добавлена в каталог');
    } else {
        window.alert('При заполнении формы были допущены ошибки\n' +
            'Пожалуйста, исправьте их и попробуйте снова\n' +
            'Список ошибок приведен наверху страницы');
    }

    return flag;
}

function checkMileageCompatibility(mileage, state){
    return state == 'Подержанный'
        || (state == 'Новый'
        && Number(mileage) === 0);
}


function checkConsumptionCompatibility(engine, consumption) {
    return (engine == 'Бензиновый' && Number(consumption) >= 4)
        || (engine == 'Дизельный' && Number(consumption) >=3);
}

function checkTransmissionCompatibility(type, levels){
    return (type == "МКПП" && Number(levels) >= 4)
    || (type == "АКПП");
}

function checkYearCompatability(state, year){
    return (state == "Новый" && (new Date().getFullYear() - Number(year) < 3 )
        || (state == "Подержаный"));
}

function checkYear(year){
    return Number(year) <= new Date().getFullYear();
}

function dropHighlighting(){
    document.getElementById('year').style.color = 'black';
    document.getElementById('mileage').style.color = 'black';
    document.getElementById('transmissionlevels').style.color = 'black';
    document.getElementById('consumption').style.color = 'black';
}

function resetErrorBoxes(){
    document.getElementById('year-error').innerHTML = '';
    document.getElementById('mileage-error').innerHTML = '';
    document.getElementById('transmissionlevels-error').innerHTML = '';
    document.getElementById('consumption-error').innerHTML = '';
}