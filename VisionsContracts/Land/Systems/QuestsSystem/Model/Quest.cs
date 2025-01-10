using System;
using System.Collections.Generic;
using System.Numerics;
using VisionsContracts.Items.Model;
using VisionsContracts.Land.Model;
using VisionsContracts.Land.Systems.CraftingSystem.Model;
using VisionsContracts.Transformations.Model;

namespace VisionsContracts.Land.Systems.QuestsSystem.Model
{


    public class Quest
    {
        public virtual BigInteger Id { get; set; }
        public virtual BigInteger Duration { get; set; }
        public virtual bool Exists { get; set; }
        public virtual string QuestName { get; set; }
        public virtual List<QuestTask> Tasks { get; set; } = new List<QuestTask>();
        public virtual List<Reward> Rewards { get; set; } = new List<Reward>();

        public Quest() { }

        public Quest(BigInteger id, BigInteger duration, bool exists, string questName, List<QuestTask> tasks, List<Reward> rewards)
        {
            Id = id;
            Duration = duration;
            Exists = exists;
            QuestName = questName;
            Tasks = tasks;
            Rewards = rewards;
        }

        public Quest(BigInteger id, string questName, Transformation transformation, int taskQuantity, Reward reward, bool exists = true)
        {
            Id = id;
            Exists = exists;
            QuestName = questName;
            Tasks.Add(new QuestTask(id, transformation, taskQuantity));
            Rewards.Add(reward);
        }

        public Quest(BigInteger id, string questName, Transformation transformation, int taskQuantity, params Reward[] rewards)
        {
            Id = id;
            Exists = true;
            QuestName = questName;
            Tasks.Add(new QuestTask(id, transformation, taskQuantity));
            Rewards.AddRange(rewards);
        }

        public Quest(BigInteger id, string questName, TransformationCategory transformationCategory, int taskQuantity, Reward reward, bool exists = true)
        {
            Id = id;
            Exists = exists;
            QuestName = questName;
            Tasks.Add(new QuestTask(id, transformationCategory, taskQuantity));
            Rewards.Add(reward);
        }

        public Quest(BigInteger id, string questName, TransformationCategory transformationCategory, int taskQuantity, params Reward[] rewards)
        {
            Id = id;
            Exists = true;
            QuestName = questName;
            Tasks.Add(new QuestTask(id, transformationCategory, taskQuantity));
            Rewards.AddRange(rewards);
        }

        public Quest(BigInteger id, string questName, Stacking stacking, int taskQuantity, Reward reward, bool exists = true)
        {
            Id = id;
            Exists = exists;
            QuestName = questName;
            Tasks.Add(new QuestTask(id, stacking, taskQuantity));
            Rewards.Add(reward);
        }

        public Quest(BigInteger id, string questName, Stacking stacking, int taskQuantity, params Reward[] rewards)
        {
            Id = id;
            Exists = true;
            QuestName = questName;
            Tasks.Add(new QuestTask(id, stacking, taskQuantity));
            Rewards.AddRange(rewards);
        }

        public Quest(BigInteger id, string questName, CraftingRecipe craftingRecipe, int taskQuantity, params Reward[] rewards)
        {
            Id = id;
            Exists = true;
            QuestName = questName;
            Tasks.Add(new QuestTask(id, craftingRecipe, taskQuantity));
            Rewards.AddRange(rewards);
        }

        public Quest(BigInteger id, string questName, Item item, int taskQuantity, Reward reward, bool exists = true)
        {
            Id = id;
            Exists = exists;
            QuestName = questName;
            Tasks.Add(new QuestTask(id, item, taskQuantity));
            Rewards.Add(reward);
        }

        public Quest(BigInteger id, string questName, Item item, int taskQuantity, params Reward[] rewards)
        {
            Id = id;
            Exists = true;
            QuestName = questName;
            Tasks.Add(new QuestTask(id, item, taskQuantity));
            Rewards.AddRange(rewards);
        }
    }

    

}
