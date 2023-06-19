CREATE TABLE IF NOT EXISTS `mydb`.`user_account` (
  `id_user` VARCHAR(11) NOT NULL,
  `password` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_user`),
  UNIQUE INDEX `id_user_UNIQUE` (`id_user` ASC) VISIBLE,
  CONSTRAINT `user_id_key`
    FOREIGN KEY (`id_user`)
    REFERENCES `mydb`.`users_data` (`id_user`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
KEY_BLOCK_SIZE = 4;

CREATE TABLE IF NOT EXISTS `mydb`.`users_data` (
  `id_user` VARCHAR(11) NOT NULL,
  `name` VARCHAR(45) NOT NULL,
  `surname` VARCHAR(45) NOT NULL,
  `e_maill` VARCHAR(45) NULL,
  `phone` VARCHAR(9) NULL,
  `stanowisko` VARCHAR(45) NULL,
  `rola` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_user`),
  UNIQUE INDEX `id_user_UNIQUE` (`id_user` ASC) VISIBLE)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `mydb`.`orders` (
  `idorders` INT NOT NULL,
  `name_mecinin` VARCHAR(45) NULL,
  `date` DATE NULL,
  `iduser` VARCHAR(11) NULL,
  PRIMARY KEY (`idorders`),
  INDEX `id_name_key_idx` (`name_mecinin` ASC) VISIBLE,
  INDEX `user_key_idx` (`iduser` ASC) VISIBLE,
  CONSTRAINT `id_name_key`
    FOREIGN KEY (`name_mecinin`)
    REFERENCES `mydb`.`medicines` (`name_m`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `user_key`
    FOREIGN KEY (`iduser`)
    REFERENCES `mydb`.`users_data` (`id_user`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `mydb`.`medicines` (
  `name_m` VARCHAR(30) NOT NULL,
  `substance` VARCHAR(45) NOT NULL,
  `form` VARCHAR(45) NOT NULL,
  `price` REAL NULL,
  PRIMARY KEY (`name_m`))
ENGINE = InnoDB