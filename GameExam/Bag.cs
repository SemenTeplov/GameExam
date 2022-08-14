using System.Collections.Generic;

namespace GameExam
{
    public class Bag
    {
        public Bag() 
        {
            eats = new List<Eat>();
            equipments = new List<Equipment>();
        }

        public void setEat(Eat eat)
        {
            eats.Add(eat);
        }
        public void setEquipment(Equipment equipment)
        {
            equipments.Add(equipment);
        }
        public Eat getEat(int indx)
        {
            return eats[indx];
        }
        public Equipment getEquipment(int indx)
        {
            return equipments[indx];
        }
        public int getCountEat()
        {
            return eats.Count;
        }
        public int getCountEquipment()
        {
            return equipments.Count;
        }
        public void removeEat(int indx)
        {
            eats.RemoveAt(indx);
        }
        public void removeEquipment(int indx)
        {
            equipments.RemoveAt(indx);
        }

        private List<Eat> eats;
        private List<Equipment> equipments;
    }
}
