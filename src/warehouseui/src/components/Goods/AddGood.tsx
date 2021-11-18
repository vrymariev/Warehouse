import  { useEffect, useState } from 'react';
import { useHistory, useParams } from 'react-router-dom';
import DatePicker from 'react-datepicker';


import "react-datepicker/dist/react-datepicker.css";
import cloneDeep from 'lodash-es/cloneDeep';
import { GoodType, Manufacturer } from '../../Types/types';

const AddGood = () => {
    const [model, setModel] = useState<GoodType>({} as GoodType);
    const [manufacturers, setManufacturers] = useState<Manufacturer[]>();
    let history = useHistory();
    const { goodId } = useParams();
    const fetchManufacturesFromServer = () => {
        fetch("http://localhost:5000/manufactures").then((response) => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error('Something went wrong');
            }
        })
        .then((result) => {
            setManufacturers(result);
        }).catch((error) => {
            alert('помилка завантаження категорій');
        });
    };
    
    useEffect(() => {
        fetchManufacturesFromServer();
    }, []);

    const saveModel = () => {
        fetch("http://localhost:5000/goods/" + goodId,
        {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(model)
        }).then((response) => {
            if (!response.ok) {
                throw new Error('Something went wrong');
            }
            })
        .then((result) => {
            alert('Додано');
            history.push('/goods');
        }).catch((error) => {
            alert('помилка');
        });
    };

    const onDateChanged = (date: Date) => {
        var currentModel = cloneDeep(model) as GoodType;
        currentModel.registrationDate = date;
        setModel(currentModel);
    };

    const onManufacturerChanged = (manufacturerId: string) => {
        var manufacturer = manufacturers?.find((element) => {
            return element.id == Number(manufacturerId);
        });
        var currentModel = cloneDeep(model) as GoodType;
        currentModel.manufacturer = manufacturer;
        currentModel.manufacturerId = Number(manufacturerId);
        setModel(currentModel);
    };

    const onNameChanged = (value: string) => {
        var currentModel = cloneDeep(model) as GoodType;
        currentModel.name = value;
        setModel(currentModel);
    };

    const onCountChanged = (value: string) => {
        var currentModel = cloneDeep(model) as GoodType;
        currentModel.count = Number(value);
        setModel(currentModel);
    };

    const onPriceChanged = (value: string) => {
        var currentModel = cloneDeep(model) as GoodType;
        currentModel.price = Number(value);
        setModel(currentModel);
    };

    const onCategoryChanged = (value: string) => {
        var currentModel = cloneDeep(model) as GoodType;
        currentModel.category = value;
        setModel(currentModel);
    };

    var date = model.registrationDate ? new Date(model.registrationDate) : new Date();

    return (
        <div>
            <h4>Новий товар</h4>
            <div>Назва:</div>
            <div>
                <input type="text" defaultValue={model?.name} onChange={(e) => onNameChanged(e.target.value)} />
            </div>
            <div>Кількість:</div>
            <div>
                <input type="number" min="0" defaultValue={model?.count} onChange={(e) => onCountChanged(e.target.value)} />
            </div>
            <div>Виробник:</div>
            <div>
                <select onChange={(e) => onManufacturerChanged(e.target.value)}>
                    <option value={''}></option>
                    {manufacturers?.map((item, index) => {     
                        return (
                            <option key={index} value={item.id}>{item.name}</option>
                        ) 
                    })}
                </select>
            </div>
            <div>Ціна:</div>
            <div>
                <input type="number" min="0" defaultValue={model?.price} onChange={(e) => onPriceChanged(e.target.value)} />
            </div>
            <div>Категорія:</div>
            <div>
                <input type="text" defaultValue={model?.category} onChange={(e) => onCategoryChanged(e.target.value)} />
            </div>
            <div>Дата реєстрації:</div>
            <div>
                <DatePicker
                    dateFormat="dd-MM-yyyy"
                    selected={date}
                    onChange={(date: Date) => onDateChanged(date)}
                />
            </div>
            <button onClick={() => saveModel()}>Додати</button>
        </div>
    );
}

export default AddGood;